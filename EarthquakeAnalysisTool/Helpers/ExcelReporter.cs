using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace EqAT.Helpers
{
    public struct ExcelReporterOptions
    {
        public BackgroundWorker Worker { get; set; }
        public string WorkbookFilePath { get; set; }
        public bool CalculateDisplacements { get; set; }
        public RPMaker MyResponseSpectraMaker { get; set; }
        public FASMaker MyFourierSpectraMaker { get; set; }
        /// <summary>
        /// Yield Acceleration in g
        /// </summary>
        public decimal YieldAccel { get; set; }
    }

    public class ExcelReporter
    {
        private string mPath;

        /// <summary>
        /// ATH from Shake91
        /// </summary>
        public SurfaceATHMaker MySurfaceATHMaker { get; set; }
        /// <summary>
        /// ATH from Earthquake Location
        /// </summary>
        public BaseATHMaker MyBaseATHMaker { get; set; }

        private Microsoft.Office.Interop.Excel.Application mExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        private Workbook mWorkBook;

        public string ExcelFilePath { get; set; }

        //private Worksheet mWSheet1 = new Worksheet();
        private Worksheet mwWsRS = new Worksheet();
        private Worksheet mWsFS = new Worksheet();

        private BackgroundWorker mBwApp;

        private ExcelReporterOptions Options { get; set; }

        private List<string> accBase;
        private double[] timeStepsBase;

        int startRow = 3;

        /// <summary>
        /// Filepath of the Excel Report file
        /// </summary>
        /// <param name="fp"></param>
        public ExcelReporter(ExcelReporterOptions options)
        {
            this.Options = options;
            this.mPath = options.WorkbookFilePath;
            this.mBwApp = options.Worker;
        }

        /// <summary>
        /// Export ATH to Excel
        /// </summary>
        public void CreateReport()
        {
            //try
            //{
            //************************
            //* Initialize Worksheets
            //************************

            mExcelApp.DisplayAlerts = false;

            mWorkBook = mExcelApp.Workbooks.Add(Missing.Value);
            Sheets mWorkSheets = mWorkBook.Worksheets as Sheets;

            // mWSheet1 = (Worksheet)mWorkSheets.get_Item("Sheet1");
            mwWsRS = (Worksheet)mWorkSheets.get_Item("Sheet2");
            mWsFS = (Worksheet)mWorkSheets.get_Item("Sheet3");

            if (this.MyBaseATHMaker != null && this.MySurfaceATHMaker != null)
            {
                MySurfaceATHMaker.ReadATH();
                accBase = MyBaseATHMaker.ReadATH();

                foreach (ATH ath in MySurfaceATHMaker.ATHMgr)
                {
                    Worksheet ws = (Worksheet)mExcelApp.ActiveWorkbook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    FillATHData(ath, ws);
                    GenerateChartATH(ws);
                }
            }
            if (this.Options.MyResponseSpectraMaker != null)
            {
                FillRPData(mwWsRS);
                FillFASData(mWsFS, this.Options.MyFourierSpectraMaker);
                GenerateChartFASf(mWsFS, this.Options.MyFourierSpectraMaker);
                GenerateChartFASp(mWsFS, this.Options.MyFourierSpectraMaker);
                FillCodeData(mwWsRS);
                GenerateChartRP(mwWsRS);
            }

            // AutofitColumns(mWSheet1, "A1", "Z1");
            AutofitColumns(mwWsRS, "A1", "H1");
            AutofitColumns(mWsFS, "A1", "H1");

            //Range time1 = (Range)mWSheet1.Columns["A", Missing.Value];
            //time1.ColumnWidth = 8.5;
            //time1 = (Range)mWSheet1.Columns["H", Missing.Value];
            //time1.ColumnWidth = 8.5;

            //mWSheet1.Name = "ATH and DTH Data";
            mwWsRS.Name = "Response Spectra Data";
            mWsFS.Name = "Fourier Spectra Data";
            //mWSheet1.Select(true);

            string ext = Path.GetExtension(mPath);

            if (ext.ToLower().Equals(".xlsx"))
            {
                ExcelFilePath = SaveAs2007(mPath);
            }
            else if (ext.ToLower().Equals(".xls"))
            {
                ExcelFilePath = SaveAs2003(mPath);
            }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());                
            //}

            //finally
            //{
            mExcelApp.DisplayAlerts = true;
            mExcelApp.Quit();
            // }

        }

        private void GenerateChartFASp(Worksheet ws, FASMaker fasm)
        {
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);

            ChartObject chartObj = chartObjs.Add(500, 20, 640, 480);
            Chart xlChart = chartObj.Chart;

            SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection(Type.Missing);

            seriesCollection.NewSeries();
            seriesCollection.Item(1).Name = "Fourier Amplitude Spectra";
            seriesCollection.Item(1).XValues = string.Format("={0}!$B{1}:$B{2}", ws.Name, startRow, fasm.PeriodList.Count);
            seriesCollection.Item(1).Values = string.Format("={0}!$C{1}:$C{2}", ws.Name, startRow, fasm.FourierAmplitudesList.Count);

            xlChart.ChartType = XlChartType.xlXYScatterSmoothNoMarkers;

            // Customize axes:
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "Period (s)";
            xAxis.MaximumScale = fasm.Options.XaxisMaxScale;

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Fourier Amplitude (g-s)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Fourier Amplitude Spectra";
            // Remove legend:
            xlChart.HasLegend = false;

            xlChart.Location(XlChartLocation.xlLocationAsNewSheet, "Fourier Spectra (p)");

        }

        private void GenerateChartFASf(Worksheet ws, FASMaker fasm)
        {
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);

            ChartObject chartObj = chartObjs.Add(500, 20, 640, 480);
            Chart xlChart = chartObj.Chart;

            SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection(Type.Missing);

            seriesCollection.NewSeries();
            seriesCollection.Item(1).Name = "Fourier Amplitude Spectra";
            seriesCollection.Item(1).XValues = string.Format("={0}!$A{1}:$A{2}", ws.Name, startRow, fasm.FreqList.Count);
            seriesCollection.Item(1).Values = string.Format("={0}!$C{1}:$C{2}", ws.Name, startRow, fasm.FourierAmplitudesList.Count);

            xlChart.ChartType = XlChartType.xlXYScatterSmoothNoMarkers;

            // Customize axes:
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "Frequency (Hz)";
            // xAxis.MaximumScale = fasm.Options.XaxisMaxScale;

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Fourier Amplitude (g-s)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Fourier Amplitude Spectra";
            // Remove legend:
            xlChart.HasLegend = false;

            xlChart.Location(XlChartLocation.xlLocationAsNewSheet, "Fourier Spectra (f)");

        }

        private void FillFASData(Worksheet ws, FASMaker fasm)
        {
            ws.Cells[2, 1] = "Frequency (Hz)";
            ws.Cells[2, 2] = "Period (s)";
            ws.Cells[2, 3] = "Fourier Amplitude (g-s)";

            fasm.ReadData();

            if (fasm.FourierAmplitudesList.Count > 0 && fasm.FreqList.Count > 0)
            {
                List<string> f = fasm.FreqList;
                List<string> p = fasm.PeriodList;
                List<string> acc = fasm.FourierAmplitudesList;
                double[,] arrData = new double[f.Count, 3];
                for (int i = 0; i < f.Count; i++)
                {
                    double.TryParse(f[i], out arrData[i, 0]);
                    double.TryParse(p[i], out arrData[i, 1]);
                    double.TryParse(acc[i], out arrData[i, 2]);
                }
                Range rng = ws.get_Range(string.Format("A{0}", startRow), string.Format("C{0}", startRow + acc.Count - 1));
                rng.Value2 = arrData;
            }

            ws.Cells[2, 5] = "Bandwidth (Hz)";
            ws.Cells[2, 6] = "from";
            ws.Cells[2, 7] = this.Options.MyFourierSpectraMaker.BandwidthStart;
            ws.Cells[3, 6] = "to";
            ws.Cells[3, 7] = this.Options.MyFourierSpectraMaker.BandwidthFinish;

        }

        private void FillRPData(Worksheet ws)
        {
            try
            {
                ws.Cells[2, 1] = "Period (s)";
                ws.Cells[2, 2] = "Accl(g)";

                this.Options.MyResponseSpectraMaker.ReadData();
                if (this.Options.MyResponseSpectraMaker.ATH.Count > 0 && this.Options.MyResponseSpectraMaker.PeriodList.Count > 0)
                {
                    List<string> p = this.Options.MyResponseSpectraMaker.PeriodList;
                    List<string> acc = this.Options.MyResponseSpectraMaker.ATH;
                    double[,] arrData = new double[p.Count, 2];
                    for (int i = 0; i < p.Count; i++)
                    {
                        double.TryParse(p[i], out arrData[i, 0]);
                        double.TryParse(acc[i], out arrData[i, 1]);
                    }
                    Range rng = ws.get_Range(string.Format("A{0}", startRow), string.Format("B{0}", startRow + acc.Count - 1));
                    rng.Value2 = arrData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void FillCodeData(Worksheet ws)
        {
            // Fill Code Data
            ws.Cells[1, 4] = "Code";
            ws.Cells[2, 4] = "Period (s)";
            ws.Cells[2, 5] = "Rock Ch";
            ws.Cells[2, 6] = "Rock Accl (g)";
            ws.Cells[2, 7] = "Strong Rock Ch";
            ws.Cells[2, 8] = "Strong Rock Accl (g)";

            Range headings = ws.get_Range("A1", "H2");
            headings.Font.Bold = true;

            double[,] arrCol = { { 0 }, { 0.1 }, { 0.2 }, { 0.3 }, { 0.4 }, { 0.5 }, { 0.6 }, { 0.7 }, { 0.8 }, { 0.9 }, { 1 }, { 1.2 }, { 1.5 }, { 1.7 }, { 2 }, { 2.5 }, { 3 }, { 3.5 }, { 4 }, { 4.5 }, { 5 } };
            Range rTime = ws.get_Range(string.Format("D{0}", startRow), string.Format("D{0}", startRow + 20));
            rTime.Value2 = arrCol;

            ws.Cells[1, 10] = "kp";
            Range kp = (Range)ws.Cells[1, 11];
            kp.Name = "kp";
            kp.Value2 = 1;
            // kp.Style = "Input";

            ws.Cells[1, 12] = "pga";
            Range pga = (Range)ws.Cells[1, 13];
            pga.Name = "pga";
            pga.Value2 = 0.09;
            //pga.Style = "Input";

            double[,] arrRockCh = { { 1 }, { 2.94 }, { 2.94 }, { 2.94 }, { 2.2 }, { 1.76 }, { 1.47 }, { 1.26 }, { 1.1 }, { 0.98 }, { 0.88 }, { 0.73 }, { 0.59 }, { 0.46 }, { 0.33 }, { 0.21 }, { 0.15 }, { 0.11 }, { 0.083 }, { 0.065 }, { 0.053 } };
            Range rRockCh = ws.get_Range(string.Format("E{0}", startRow), string.Format("E{0}", startRow + 20));
            rRockCh.Value2 = arrRockCh;

            string[,] arrFormulae = new string[21, 1];
            Range rRockChAcc = ws.get_Range(string.Format("F{0}", startRow), string.Format("F{0}", startRow + 20));
            for (int i = 0; i < 21; i++)
            {
                arrFormulae[i, 0] = "=RC[-1]*pga*kp";
            }
            rRockChAcc.FormulaArray = arrFormulae;

            double[,] arrStrongRockCh = { { 0.8 }, { 2.35 }, { 2.35 }, { 2.35 }, { 1.76 }, { 1.41 }, { 1.17 }, { 1.01 }, { 0.88 }, { 0.78 }, { 0.7 }, { 0.59 }, { 0.47 }, { 0.37 }, { 0.26 }, { 0.17 }, { 0.12 }, { 0.086 }, { 0.066 }, { 0.052 }, { 0.042 } };
            Range rStrongRockCh = ws.get_Range(string.Format("G{0}", startRow), string.Format("G{0}", startRow + 20));
            rStrongRockCh.Value2 = arrStrongRockCh;

            Range rStrongRockChAcc = ws.get_Range(string.Format("H{0}", startRow), string.Format("H{0}", startRow + 20));
            for (int i = 0; i < 21; i++)
            {
                arrFormulae[i, 0] = "=RC[-1]*pga*kp";
            }
            rStrongRockChAcc.FormulaArray = arrFormulae;
        }

        private void FillATHData(ATH ath, Worksheet ws)
        {

            int dtBase = MyBaseATHMaker.DT;

            mBwApp.ReportProgress(0, (this.Options.CalculateDisplacements ? 10 : 4));
            mBwApp.ReportProgress(2, "Filling Base ATH, VTH and DTH...");

            double[,] arrData = new double[accBase.Count, 1];
            string[,] arrString = new string[accBase.Count, 1];

            Range headings = ws.get_Range("A1", "Z2");
            headings.Font.Bold = true;

            ws.Cells[1, 1] = "Base: " + MyBaseATHMaker.Title;

            // Times
            timeStepsBase = new double[accBase.Count];
            ws.Cells[2, 1] = "Time (s)";
            Range rTime = ws.get_Range(string.Format("A{0}", startRow), string.Format("A{0}", startRow + accBase.Count - 1));
            for (int i = 0; i < accBase.Count; i++)
            {
                timeStepsBase[i] = (double)(i * dtBase / 1000.0);
                arrData[i, 0] = timeStepsBase[i];
            }
            rTime.Value2 = arrData;
            rTime.Style = "Input";
            mBwApp.ReportProgress(1);

            // ATH (G)
            ws.Cells[2, 2] = "Accel (g)";
            Range rAthG = ws.get_Range(string.Format("B{0}", startRow), string.Format("B{0}", startRow + accBase.Count - 1));
            for (int i = 0; i < accBase.Count; i++)
            {
                double value;
                double.TryParse(accBase[i], out value);
                arrData[i, 0] = value;
            }
            rAthG.Value2 = arrData;
            rAthG.Style = "Input";
            mBwApp.ReportProgress(1);

            if (this.Options.CalculateDisplacements)
            {
                // ATH (m/ss)
                ws.Cells[2, 3] = "Accel (m/ss)";
                Range rAth = ws.get_Range(string.Format("C{0}", startRow), string.Format("C{0}", startRow + accBase.Count - 1));
                for (int i = 0; i < accBase.Count; i++)
                {
                    arrString[i, 0] = "=RC[-1]*9.81";
                }
                rAth.FormulaArray = arrString;
                rAth.Style = "Calculation";
                mBwApp.ReportProgress(1);

                // VTH (m/s)
                ws.Cells[2, 4] = "veloc (m/s)";
                Range rVth = ws.get_Range(string.Format("D{0}", startRow + 1), string.Format("D{0}", startRow + accBase.Count - 1));
                for (int i = 0; i < accBase.Count; i++)
                {
                    arrString[i, 0] = "=0.5*(RC[-1]+R[-1]C[-1])*(RC[-3]-R[-1]C[-3])+R[-1]C";
                }
                rVth.FormulaArray = arrString;
                rVth.Style = "Calculation";
                mBwApp.ReportProgress(1);

                // DTH (m)
                ws.Cells[2, 5] = "disp (m)";
                Range rDth = ws.get_Range(string.Format("E{0}", startRow + 1), string.Format("E{0}", startRow + accBase.Count - 1));
                for (int i = 0; i < accBase.Count; i++)
                {
                    arrString[i, 0] = "=0.5*(RC[-1]+R[-1]C[-1])*(RC[-4]-R[-1]C[-4])+R[-1]C";
                }
                rDth.FormulaArray = arrString;
                rDth.Style = "Output";
                mBwApp.ReportProgress(1);

            }


            List<string> accSurface = MySurfaceATHMaker.ATHMgr[0].Readings;
            double dt = ((double)accBase.Count / (double)accSurface.Count) * dtBase;

            arrData = new double[accSurface.Count, 1];
            arrString = new string[accSurface.Count, 1];

            mBwApp.ReportProgress(2, "Filling Base ATH, VTH and DTH...");

            ws.Cells[1, 8] = "Surface: " + ath.Title;

            // Times
            ws.Cells[2, 8] = "Time (s)";
            Range rTimeS = ws.get_Range(string.Format("H{0}", startRow), string.Format("H{0}", startRow + accSurface.Count - 1));
            for (int i = 0; i < accSurface.Count; i++)
            {
                arrData[i, 0] = (double)(i * dt / 1000.0);
            }
            rTimeS.Value2 = arrData;
            rTimeS.Style = "Input";
            mBwApp.ReportProgress(1);

            // ATH (G)
            ws.Cells[2, 9] = "Accel (g)";
            Range rAthGS = ws.get_Range(string.Format("I{0}", startRow), string.Format("I{0}", startRow + accSurface.Count - 1));
            for (int i = 0; i < accSurface.Count; i++)
            {
                double value;
                double.TryParse(accSurface[i], out value);
                arrData[i, 0] = value;
            }
            rAthGS.Value2 = arrData;
            rAthGS.Style = "Input";
            mBwApp.ReportProgress(1);

            if (this.Options.CalculateDisplacements)
            {
                // ATH (m/ss)
                ws.Cells[2, 10] = "Accel (m/ss)";
                Range rAthS = ws.get_Range(string.Format("J{0}", startRow), string.Format("J{0}", startRow + accSurface.Count - 1));
                for (int i = 0; i < accSurface.Count; i++)
                {
                    arrString[i, 0] = "=RC[-1]*9.81";
                }
                rAthS.FormulaArray = arrString;
                rAthS.Style = "Calculation";
                mBwApp.ReportProgress(1);

                // VTH (m/s)
                ws.Cells[2, 11] = "veloc (m/s)";
                Range rVthS = ws.get_Range(string.Format("K{0}", startRow + 1), string.Format("K{0}", startRow + accSurface.Count - 1));
                for (int i = 0; i < accSurface.Count; i++)
                {
                    arrString[i, 0] = "=0.5*(RC[-1]+R[-1]C[-1])*(RC[-3]-R[-1]C[-3])+R[-1]C";
                }
                rVthS.FormulaArray = arrString;
                rVthS.Style = "Calculation";
                mBwApp.ReportProgress(1);

                // DTH (m)
                ws.Cells[2, 12] = "disp (m)";
                Range rDthS = ws.get_Range(string.Format("L{0}", startRow + 1), string.Format("L{0}", startRow + accSurface.Count - 1));
                for (int i = 0; i < accSurface.Count; i++)
                {
                    arrString[i, 0] = "=0.5*(RC[-1]+R[-1]C[-1])*(RC[-4]-R[-1]C[-4])";
                }
                rDthS.FormulaArray = arrString;
                rDthS.Style = "Output";
                mBwApp.ReportProgress(1);

                // DTH (m) above yield acceleration
                ws.Cells[2, 12] = "disp (m)";

                ws.Cells[1, 15] = "Yield Accel (g)";
                ws.Cells[2, 15] = "Disp  (m)";
                ws.Cells[3, 15] = "Disp (mm)";
                Range ay = (Range)ws.Cells[1, 16];
                ay.Name = "ay";
                ay.Value2 = this.Options.YieldAccel;
                ay.Style = "Input";
                Range rDthAy = ws.get_Range(string.Format("M{0}", startRow + 1), string.Format("M{0}", startRow + accSurface.Count - 1));
                for (int i = 0; i < accSurface.Count; i++)
                {
                    arrString[i, 0] = "=IF(RC[-4]>ay,RC[-1],0)";
                }
                rDthAy.FormulaArray = arrString;
                rDthAy.Style = "Output";

                // Total Positive Displacement above Yield Acceleration
                ws.Cells[2, 13] = "disp (above a_y)";
                Range disp = (Range)ws.Cells[2, 16];
                disp.FormulaR1C1 = string.Format("=SUM(R[{0}]C[-3]:R[{1}]C[-3])", startRow - 1, accSurface.Count + startRow - 1);
                disp.Style = "Calculation";
                // also show in mm
                Range disp_mm = (Range)ws.Cells[3, 16];
                disp_mm.FormulaR1C1 = "=R[-1]C*1000";
                disp_mm.Style = "Output";

                mBwApp.ReportProgress(1);

            } // Calculate Displacements

            FillStatistics(ws);

            // Number Formatting

            SetNumberFormat(ws, "B1", "E1", "0.0000E+00");
            SetNumberFormat(ws, "I1", "L1", "0.0000E+00");



          //  ws.Name = ath.Title.Trim();

            mBwApp.ReportProgress(2, "Ready");

        }

        private void FillStatistics(Worksheet ws)
        {
            //*************
            // Statistics
            //*************

            int headingStatsRow = 6;
            ws.Cells[headingStatsRow, 15] = "Statistics";
            ((Range)ws.Cells[headingStatsRow, 15]).Style = "Heading 1";

            // Bracketed Duration

            double a_threshold = 0.05;
            //ws.Cells[headingStatsRow + 1, 15] = "Threshold Accel";
            //ws.Cells[headingStatsRow + 1, 16] = a_threshold;

            double t_first = 0.0;
            double t_last = 0.0;
            bool bFirst = false;

            for (int i = 0; i < accBase.Count; i++)
            {
                if (Math.Abs(double.Parse(accBase[i])) > a_threshold)
                {
                    if (!bFirst)
                    {
                        t_first = timeStepsBase[i];
                        bFirst = true;
                    }
                    else
                    {
                        t_last = timeStepsBase[i];
                    }
                }
            }

            ws.Cells[headingStatsRow + 2, 15] = "Duration (s)";
            ws.Cells[headingStatsRow + 2, 16] = t_last - t_first;
            ((Range)ws.Cells[headingStatsRow + 2, 16]).Style = "Output";

            // Peak Acceleration 
            ws.Cells[headingStatsRow + 3, 15] = "Peak accel (g)";
            ((Range)ws.Cells[headingStatsRow + 3, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow, startRow + accBase.Count - 1, -13);

            if (this.Options.CalculateDisplacements)
            {
                // Peak Velocity 
                ws.Cells[headingStatsRow + 4, 15] = "Peak velo (m/s)";
                ((Range)ws.Cells[headingStatsRow + 4, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow + 1, startRow + accBase.Count - 1, -12);

                // Peak Displacement 
                ws.Cells[headingStatsRow + 5, 15] = "Peak disp (m)";
                ((Range)ws.Cells[headingStatsRow + 5, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow + 1, startRow + accBase.Count - 1, -11);
            }

            for (int i = 3; i < 6; i++)
            {
                ((Range)ws.Cells[headingStatsRow + i, 16]).Style = "Output";
            }
        }



        private void SetNumberFormat(Worksheet ws, string colStart, string colFinish, string numberFormat)
        {
            Range rng = ws.get_Range(colStart, colFinish);
            rng.NumberFormat = numberFormat;
        }

        private void GenerateChartRP(Worksheet ws)
        {
            ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
            ChartObject chartObj = chartObjs.Add(500, 20, 640, 480);
            Chart xlChart = chartObj.Chart;

            SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection(Type.Missing);

            seriesCollection.NewSeries();
            seriesCollection.Item(1).Name = "Shake91";
            seriesCollection.Item(1).XValues = string.Format("={0}!$A{1}:$A{2}", ws.Name, startRow, this.Options.MyResponseSpectraMaker.PeriodList.Count);
            seriesCollection.Item(1).Values = string.Format("={0}!$B{1}:$B{2}", ws.Name, startRow, this.Options.MyResponseSpectraMaker.ATH.Count);

            seriesCollection.NewSeries();
            seriesCollection.Item(2).Name = "AS1170.4 (Rock)";
            seriesCollection.Item(2).XValues = string.Format("={0}!R{1}C4:R{2}C4", ws.Name, startRow, startRow + 20);
            seriesCollection.Item(2).Values = string.Format("={0}!R{1}C6:R{2}C6", ws.Name, startRow, startRow + 20);

            seriesCollection.NewSeries();
            seriesCollection.Item(3).Name = "AS1170.4 (Strong Rock)";
            seriesCollection.Item(3).XValues = string.Format("={0}!R{1}C4:R{2}C4", ws.Name, startRow, startRow + 20);
            seriesCollection.Item(3).Values = string.Format("={0}!R{1}C8:R{2}C8", ws.Name, startRow, startRow + 20);

            xlChart.ChartType = XlChartType.xlXYScatterLinesNoMarkers;

            // Customize axes:
            Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = "Period (s)";
            xAxis.MaximumScale = this.Options.MyResponseSpectraMaker.Options.XaxisMaxScale;

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Acceleration (g)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Response Spectra (Shake91)";
            // Remove legend:
            xlChart.HasLegend = true;

            xlChart.Location(XlChartLocation.xlLocationAsNewSheet, "Response Spectra");

        }

        private void GenerateChartATH(Worksheet ws)
        {
            try
            {
                // Now create the chart.

                // Chart xlChart = (Chart)mWorkBook.Charts.Add(Missing.Value, Missing.Value,Missing.Value, Missing.Value);
                ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
                ChartObject chartObj = chartObjs.Add(300, 20, 960, 540);
                Chart xlChart = chartObj.Chart;


                SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection(Type.Missing);

                seriesCollection.NewSeries();
                seriesCollection.Item(1).Name = "Base";
                seriesCollection.Item(1).XValues = string.Format("={0}!$A{1}:$A{2}", ws.Name, startRow, MyBaseATHMaker.ATH.Count);
                seriesCollection.Item(1).Values = string.Format("={0}!$B{1}:$B{2}", ws.Name, startRow, MyBaseATHMaker.ATH.Count);

                seriesCollection.NewSeries();
                seriesCollection.Item(2).Name = "Surface";
                seriesCollection.Item(2).XValues = string.Format("={0}!R{1}C8:R{2}C8", ws.Name, startRow, MySurfaceATHMaker.ATHMgr[0].Readings.Count);
                seriesCollection.Item(2).Values = string.Format("={0}!R{1}C9:R{2}C9", ws.Name, startRow, MySurfaceATHMaker.ATHMgr[0].Readings.Count);

                xlChart.ChartType = XlChartType.xlXYScatterSmoothNoMarkers;

                // Customize axes:
                Axis xAxis = (Axis)xlChart.Axes(XlAxisType.xlCategory,
                    XlAxisGroup.xlPrimary);
                xAxis.HasTitle = true;
                xAxis.AxisTitle.Text = "Time (s)";

                Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                    XlAxisGroup.xlPrimary);
                yAxis.HasTitle = true;
                yAxis.AxisTitle.Text = "Acceleration (g)";

                // Add title:
                xlChart.HasTitle = true;
                xlChart.ChartTitle.Text = "Acceleration Time History";
                // Remove legend:
                xlChart.HasLegend = true;


                xlChart.Location(XlChartLocation.xlLocationAsNewSheet, "ATH (Base vs. Surface)");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                mExcelApp.Quit();
            }

        }

        public string SaveAs2003(string filePath)
        {
            mWorkBook.SaveAs(filePath,
                             Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                             Missing.Value,
                             Missing.Value,
                             Missing.Value,
                             Missing.Value,
                             Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                             Missing.Value,
                             Missing.Value,
                             Missing.Value,
                             Missing.Value,
                             Missing.Value);

            return filePath;
        }

        public string SaveAs2003(string dir, string fileName)
        {
            return SaveAs2003(Path.Combine(dir, fileName + ".xls"));
        }

        public string SaveAs2007(string filePath)
        {
            mWorkBook.SaveAs(filePath,
                  Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                  Missing.Value,
                  Missing.Value,
                  Missing.Value,
                  Missing.Value,
                  Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                  Missing.Value,
                  Missing.Value,
                  Missing.Value,
                  Missing.Value,
                  Missing.Value);

            return filePath;
        }

        public string SaveAs2007(string dir, string fileName)
        {
            return (Path.Combine(dir, fileName + ".xlsx"));
        }

        private void AutofitColumns(Worksheet ws, string colStart, string colFinish)
        {
            Microsoft.Office.Interop.Excel.Range oRng;
            oRng = ws.get_Range(colStart, colFinish);
            oRng.EntireColumn.AutoFit();
        }
    }
}
