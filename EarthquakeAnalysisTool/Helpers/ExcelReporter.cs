﻿using System;
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
        public bool DrawResponseSpectrum { get; set; }
        public bool CalcNewmarkDisplacements { get; set; }
        public bool CreateMultiplier { get; set; }
        public bool NewmarkImplicitIntegration { get; set; }
        public RPMaker MyResponseSpectraMaker { get; set; }
        public FASMaker MyFourierSpectraMaker { get; set; }
        /// <summary>
        /// Yield Acceleration in g
        /// </summary>
        public double YieldAccel { get; set; }
        public double NewmarkAlpha { get; set; }
        public double NewmarkBeta { get; set; }
    }

    public class ExcelReporter
    {
        private string mPath;

        /// <summary>
        /// ATH from Shake91
        /// </summary>
        public SiteTHReader MySiteData { get; set; }
        /// <summary>
        /// ATH from Earthquake Location
        /// </summary>
        public BaseATHMaker MyEqData { get; set; }

        private Microsoft.Office.Interop.Excel.Application mExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        private Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private Microsoft.Office.Interop.Excel.Sheets mWorkSheets;

        public string ExcelFilePath { get; set; }

        private Microsoft.Office.Interop.Excel.Worksheet mWSheetATH = new Microsoft.Office.Interop.Excel.WorksheetClass();
        private Worksheet mWSheet2 = new Worksheet();
        private Worksheet mWSheet3 = new Worksheet();

        private BackgroundWorker mBwApp;

        private ExcelReporterOptions Options { get; set; }

        private List<string> m_athEq = null;
        private List<string> m_athSite = null;
        private double NewmarkDisplacement = 0.0;

        private double m_dtEq;
        private double md_dtSite;
        private List<double> m_dtSite_list = new List<double>();
        private double[] dtEq_arr;

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
            System.Windows.Forms.DialogResult ans = System.Windows.Forms.DialogResult.Yes;

            // Check if all the input files are in the same folder
            if (this.Options.MyResponseSpectraMaker.WorkingDir != this.MySiteData.WorkingDir ||
                this.MyEqData.WorkingDir != this.MySiteData.WorkingDir)
            {
                ans = System.Windows.Forms.MessageBox.Show("Not all the input files are located in the same directory. Possible cause is that you forgot to browse or drag one of the input files. Are you sure you want to continue?", "EqAT", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2);
            }

            if (ans == System.Windows.Forms.DialogResult.Yes)
            {

                mExcelApp.DisplayAlerts = false;

                //mWorkBook = mExcelApp.Workbooks.Open(mXlsFilePath, 0, false, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                mWorkBook = mExcelApp.Workbooks.Add(Missing.Value);

                mWorkSheets = mWorkBook.Worksheets;

                mWSheetATH = (Worksheet)mWorkSheets.get_Item("Sheet1");
                mWSheet2 = (Worksheet)mWorkSheets.get_Item("Sheet2");
                mWSheet3 = (Worksheet)mWorkSheets.get_Item("Sheet3");

                Worksheet wsEqAT = null;
                wsEqAT = (Worksheet)mWorkSheets.Add(mWorkSheets[1], Type.Missing, Type.Missing, Type.Missing);
                wsEqAT.Name = "EqAT " + System.Windows.Forms.Application.ProductVersion; 

                // read ATH data
                m_athEq = MyEqData.ReadATH();
                m_dtEq = MyEqData.TimeStep;
                m_athSite = MySiteData.ReadATH();

                // calculate dt for site
                md_dtSite = ((double)m_athEq.Count / (double)m_athSite.Count) * m_dtEq;
                this.NewmarkDisplacement = MySiteData.NewmarkIntegrate(md_dtSite, this.Options.YieldAccel);
                // fill scaled dt for site
                for (int i = 0; i < m_athSite.Count; i++)
                {
                    m_dtSite_list.Add((double)(i * md_dtSite));
                }

                // create multiplier data file for Plaxis
                if (this.Options.CreateMultiplier)
                {
                    string fpPlaxisDynLoadMult = Path.ChangeExtension(this.Options.WorkbookFilePath, ".mult");
                    using (StreamWriter sw = new StreamWriter(fpPlaxisDynLoadMult))
                    {
                        for (int i = 0; i < m_dtSite_list.Count; i++)
                        {
                            sw.WriteLine(string.Format("{0} {1}", m_dtSite_list[i], MySiteData.ATH_double[i] * 9.81));
                        }
                    }
                }

                // process fourier amplitude data
                this.Options.MyFourierSpectraMaker.ReadData();

                // process ath data
                if (this.Options.CalcNewmarkDisplacements)
                {
                    if (this.MyEqData != null && this.MySiteData != null)
                    {
                        FillATHData(mWSheetATH);
                        GenerateChartATH(mWSheetATH);
                    }
                }

                // process response spectra data
                if (this.Options.MyResponseSpectraMaker != null)
                {
                    FillRSData(mWSheet2);
                    FillFASData(mWSheet3, this.Options.MyFourierSpectraMaker);
                    GenerateChartFASf(mWSheet3, this.Options.MyFourierSpectraMaker);
                    GenerateChartFASp(mWSheet3, this.Options.MyFourierSpectraMaker);
                    FillCodeData(mWSheet2);
                    GenerateChartRP(mWSheet2);
                }

                AutofitColumns(mWSheetATH, "A1", "Z1");
                AutofitColumns(mWSheet2, "A1", "H1");
                AutofitColumns(mWSheet3, "A1", "H1");

                Range time1 = (Range)mWSheetATH.Columns["A", Missing.Value];
                time1.ColumnWidth = 8.5;
                time1 = (Range)mWSheetATH.Columns["H", Missing.Value];
                time1.ColumnWidth = 8.5;

                mWSheetATH.Name = "ATH and DTH Data";
                mWSheet2.Name = "Response Spectra Data";
                mWSheet3.Name = "Fourier Spectra Data";

                if (this.Options.CalcNewmarkDisplacements)
                {
                    mWSheetATH.Select(true);
                }
                else
                {
                    mWSheetATH.Delete();
                }

                string ext = Path.GetExtension(mPath);

                if (ext.ToLower().Equals(".xlsx"))
                {
                    ExcelFilePath = SaveAs2007(mPath);
                }
                else if (ext.ToLower().Equals(".xls"))
                {
                    ExcelFilePath = SaveAs2003(mPath);
                }

                mExcelApp.DisplayAlerts = true;
                mExcelApp.Quit();

            }

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
            xAxis.MinimumScale = 0.0;
            xAxis.MaximumScale = fasm.Options.XaxisMaxScale;

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Fourier Amplitude (g-s)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Fourier Amplitude Spectrum";
            xlChart.Legend.Position = XlLegendPosition.xlLegendPositionTop;
            xlChart.HasLegend = true;

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

            mBwApp.ReportProgress(2, "Filling Fourier Amplitude Spectrum data...");

            ws.Cells[2, 1] = "Frequency (Hz)";
            ws.Cells[2, 2] = "Period (s)";
            ws.Cells[2, 3] = "Fourier Amplitude (g-s)";

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

            Console.WriteLine(this.Options.MyFourierSpectraMaker.PredominantPeriod);

            //// Predominant Period
            //ws.Cells[2, 9] = "Predominant Period (s)";
            //ws.Cells[2, 10] = this.Options.MyFourierSpectraMaker.PredominantPeriod;
            //((Range)ws.Cells[2,10]).Style = "Output";

        }

        private void FillRSData(Worksheet ws)
        {

            mBwApp.ReportProgress(2, "Filling Response Spectrum data...");

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

        private void FillATHData(Worksheet ws)
        {

            if (this.Options.NewmarkImplicitIntegration)
            {

                ws.Cells[1, 24] = "α";
                ws.Cells[2, 24] = "β";

                Range alpha = (Range)ws.Cells[1, 25];
                alpha.Name = "α";
                alpha.Value2 = this.Options.NewmarkAlpha;

                Range beta = (Range)ws.Cells[2, 25];
                beta.Name = "β";
                beta.Value2 = this.Options.NewmarkBeta;

            }

            FillATHData_Eq(ws);
            FillATHData_Site(ws);

        }

        private void FillATHData_Eq(Worksheet ws)
        {
            mBwApp.ReportProgress(0, 13);
            mBwApp.ReportProgress(2, "Filling Earthquake ATH, VTH and DTH...");

            double[,] arrDouble = new double[m_athEq.Count, 1];
            string[,] arrString = new string[m_athEq.Count, 1];

            Range headings = ws.get_Range("A1", "Z2");
            headings.Font.Bold = true;

            ws.Cells[1, 1] = "Earthquake: " + MyEqData.Title;

            // Times
            dtEq_arr = new double[m_athEq.Count];
            ws.Cells[2, 1] = "Time (s)";
            Range rTime = ws.get_Range(string.Format("A{0}", startRow), string.Format("A{0}", startRow + m_athEq.Count - 1));
            for (int i = 0; i < m_athEq.Count; i++)
            {
                dtEq_arr[i] = (double)(i * m_dtEq);
                arrDouble[i, 0] = dtEq_arr[i];
            }
            rTime.Value2 = arrDouble;
            rTime.Style = "Input";
            mBwApp.ReportProgress(1);

            // ATH (G)
            ws.Cells[2, 2] = "Accel (g)";
            Range rAthG = ws.get_Range(string.Format("B{0}", startRow), string.Format("B{0}", startRow + m_athEq.Count - 1));
            for (int i = 0; i < m_athEq.Count; i++)
            {
                double value;
                double.TryParse(m_athEq[i], out value);
                arrDouble[i, 0] = value;
            }
            rAthG.Value2 = arrDouble;
            rAthG.Style = "Input";
            mBwApp.ReportProgress(1);

            // ATH (m/ss)
            ws.Cells[2, 3] = "Accel (m/ss)";
            Range rAth = ws.get_Range(string.Format("C{0}", startRow), string.Format("C{0}", startRow + m_athEq.Count - 1));
            for (int i = 0; i < m_athEq.Count; i++)
            {
                arrString[i, 0] = "=RC[-1]*9.81";
            }
            rAth.FormulaArray = arrString;
            rAth.Style = "Calculation";
            mBwApp.ReportProgress(1);


            // VTH (m/s)
            ws.Cells[2, 4] = "veloc (m/s)";
            Range rVth = ws.get_Range(string.Format("D{0}", startRow + 1), string.Format("D{0}", startRow + m_athEq.Count - 1));
            rVth.Style = "Calculation";

            // DTH (m)
            ws.Cells[2, 5] = "disp (m)";
            Range rDth = ws.get_Range(string.Format("E{0}", startRow + 1), string.Format("E{0}", startRow + m_athEq.Count - 1));
            rDth.Style = "Output";

            if (this.Options.NewmarkImplicitIntegration)
            {

                // VTH (m/s)
                for (int i = 0; i < m_athEq.Count; i++)
                {
                    arrString[i, 0] = "=R[-1]C+((1-β)*R[-1]C[-1]+β*RC[-1])*(RC[-3]-R[-1]C[-3])";
                }
                rVth.FormulaArray = arrString;
                mBwApp.ReportProgress(1);

                // DTH (m)
                for (int i = 0; i < m_athEq.Count; i++)
                {
                    arrString[i, 0] = "=R[-1]C+RC[-1]*(RC[-4]-R[-1]C[-4])+((0.5-α)*R[-1]C[-3]+α*RC[-3])*(RC[-4]-R[-1]C[-4])^2";
                }
                rDth.FormulaArray = arrString;
                mBwApp.ReportProgress(1);

            }
            else
            {

                // VTH (m/s)
                for (int i = 0; i < m_athEq.Count; i++)
                {
                    arrString[i, 0] = "=R[-1]C+0.5*(RC[-1]+R[-1]C[-1])*(RC[-3]-R[-1]C[-3])";
                }
                rVth.FormulaArray = arrString;

                mBwApp.ReportProgress(1);

                // DTH (m)
                for (int i = 0; i < m_athEq.Count; i++)
                {
                    arrString[i, 0] = "=R[-1]C+0.5*(RC[-1]+R[-1]C[-1])*(RC[-4]-R[-1]C[-4])";
                }
                rDth.FormulaArray = arrString;
                mBwApp.ReportProgress(1);

            }

        }

        private void FillATHData_Site(Worksheet ws)
        {

            double[,] arrData = new double[m_athSite.Count, 1];
            string[,] arrString = new string[m_athSite.Count, 1];

            mBwApp.ReportProgress(2, "Filling Site ATH, VTH and DTH...");

            ws.Cells[1, 8] = "Site: " + MySiteData.Title;

            // Times
            ws.Cells[2, 8] = "Time (s)";
            Range rTimeSurface = ws.get_Range(string.Format("H{0}", startRow), string.Format("H{0}", startRow + m_athSite.Count - 1));


            for (int i = 0; i < m_athSite.Count; i++)
            {
                arrData[i, 0] = m_dtSite_list[i];
            }

            rTimeSurface.Value2 = arrData;
            rTimeSurface.Style = "Input";
            mBwApp.ReportProgress(1);

            // ATH (G)
            ws.Cells[2, 9] = "Accel (g)";
            Range rAthGS = ws.get_Range(string.Format("I{0}", startRow), string.Format("I{0}", startRow + m_athSite.Count - 1));
            for (int i = 0; i < m_athSite.Count; i++)
            {
                double value;
                double.TryParse(m_athSite[i], out value);
                arrData[i, 0] = value;
            }
            rAthGS.Value2 = arrData;
            rAthGS.Style = "Input";
            mBwApp.ReportProgress(1);


            // ATH^2 
            ws.Cells[2, 10] = "Accel (m/ss)";
            Range rAthSiteSq = ws.get_Range(string.Format("T{0}", startRow), string.Format("T{0}", startRow + m_athSite.Count - 1));
            for (int i = 0; i < m_athSite.Count; i++)
            {
                arrString[i, 0] = "=RC[-10]^2";
            }
            rAthSiteSq.FormulaArray = arrString;
            rAthSiteSq.Style = "Calculation";
            mBwApp.ReportProgress(1);

            try
            {
                // Arias dI (m/s)
                ws.Cells[2, 11] = "veloc (m/s)";
                Range dAriasIntsty = ws.get_Range(string.Format("U{0}", startRow + 1), string.Format("U{0}", startRow + m_athSite.Count - 1));
                for (int i = 0; i < m_athSite.Count; i++)
                {
                    arrString[i, 0] = "=((R[-1]C[-1]+RC[-1])/2)*(RC[-13]-R[-1]C[-13])";
                }
                dAriasIntsty.FormulaArray = arrString;
                dAriasIntsty.Style = "Calculation";
                mBwApp.ReportProgress(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // ATH (m/ss)
            ws.Cells[2, 10] = "Accel (m/ss)";
            Range rAthSurface = ws.get_Range(string.Format("J{0}", startRow), string.Format("J{0}", startRow + m_athSite.Count - 1));
            for (int i = 0; i < m_athSite.Count; i++)
            {
                arrString[i, 0] = "=RC[-1]*9.81";
            }
            rAthSurface.FormulaArray = arrString;
            rAthSurface.Style = "Calculation";
            mBwApp.ReportProgress(1);

            // VTH (m/s)
            ws.Cells[2, 11] = "veloc (m/s)";
            Range rVth = ws.get_Range(string.Format("K{0}", startRow + 1), string.Format("K{0}", startRow + m_athSite.Count - 1));
            // DTH (m)
            ws.Cells[2, 12] = "disp (m)";
            Range rDth = ws.get_Range(string.Format("L{0}", startRow + 1), string.Format("L{0}", startRow + m_athSite.Count - 1));

            // VTH (m/s)
            for (int i = 0; i < m_athSite.Count; i++)
            {
                arrData[i, 0] = MySiteData.VTH_Newmark[i];
            }
            rVth.Value2 = arrData;
            mBwApp.ReportProgress(1);

            // DTH (m)
            for (int i = 0; i < m_athSite.Count; i++)
            {
                arrData[i, 0] = MySiteData.DTH_Newmark[i];
            }
            rDth.Value2 = arrData;
            mBwApp.ReportProgress(1);

            rVth.Style = "Calculation";
            rDth.Style = "Output";

            // DTH (m) above yield acceleration
            ws.Cells[2, 12] = "Disp (m)";
            ws.Cells[1, 15] = "Yield Accel (g)";
            ws.Cells[2, 15] = "Disp (mm)";
 
            Range ay = (Range)ws.Cells[1, 16];
            ay.Name = "ay";
            ay.Value2 = this.Options.YieldAccel;
            ay.Style = "Input";

            // Fill Newmark displacement
            Range disp_mm = (Range)ws.Cells[2, 16];
            disp_mm.Name = "disp_mm";
            disp_mm.Value2 = this.NewmarkDisplacement;
            disp_mm.Style = "Output";

            mBwApp.ReportProgress(1);

            FillStatistics(ws);
            FillDispSensitivity(ws);

            // Number Formatting

            SetNumberFormat(ws, "B1", "E1", "0.0000E+00");
            SetNumberFormat(ws, "I1", "L1", "0.0000E+00");

            mBwApp.ReportProgress(2, "Ready");

        }

        /// <summary>
        /// Demonstrates displacement sensitivity to Yield Acceleration
        /// </summary>
        /// <param name="ws"></param>
        private void FillDispSensitivity(Worksheet ws)
        {
            double orig_ay = (double)((Range)ws.Cells[1, 16]).Value2;
            int headingRow = 20;
            ws.Cells[headingRow, 15] = "Sensitivity";
            ws.Cells[headingRow + 1, 15] = "ay (g)";
            ws.Cells[headingRow + 1, 16] = "disp (mm)";

            ((Range)ws.Cells[headingRow, 15]).Style = "Heading 1";

            Range ay = (Range)ws.Cells[1, 16];
            double disp_mm_double = (double)((Range)ws.Cells[2, 16]).Value2; ;

            int r = headingRow + 2;

            while (disp_mm_double > 0)
            {
                ws.Cells[r, 15] = ay.Value2;
                ws.Cells[r, 16] = disp_mm_double;
                ay.Value2 = (double)ay.Value2 + 0.001;
                disp_mm_double = MySiteData.NewmarkIntegrate(md_dtSite, (double)ay.Value2);
            
                r++;
            }

            ay.Value2 = orig_ay;
        }

        private void FillStatistics(Worksheet ws)
        {
            //*************
            // Statistics
            //*************

            int headingRow = 6;
            ws.Cells[headingRow, 15] = "Statistics";
            ((Range)ws.Cells[headingRow, 15]).Style = "Heading 1";

            // Bracketed Duration

            double a_threshold = 0.05;
            //ws.Cells[headingStatsRow + 1, 15] = "Threshold Accel";
            //ws.Cells[headingStatsRow + 1, 16] = a_threshold;

            double t_first = 0.0;
            double t_last = 0.0;
            bool bFirst = false;

            for (int i = 0; i < m_athEq.Count; i++)
            {
                if (Math.Abs(double.Parse(m_athEq[i])) > a_threshold)
                {
                    if (!bFirst)
                    {
                        t_first = dtEq_arr[i];
                        bFirst = true;
                    }
                    else
                    {
                        t_last = dtEq_arr[i];
                    }
                }
            }

            ws.Cells[headingRow + 2, 15] = "Duration (s)";
            ws.Cells[headingRow + 2, 16] = t_last - t_first;
            ((Range)ws.Cells[headingRow + 2, 16]).Style = "Output";

            // Peak Acceleration 
            ws.Cells[headingRow + 3, 15] = "Peak accel (g)";
            ((Range)ws.Cells[headingRow + 3, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow, startRow + m_athEq.Count - 1, -13);
            // Peak Velocity 
            ws.Cells[headingRow + 4, 15] = "Peak velo (m/s)";
            ((Range)ws.Cells[headingRow + 4, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow + 1, startRow + m_athEq.Count - 1, -12);
            // Peak Displacement 
            ws.Cells[headingRow + 5, 15] = "Peak disp (m)";
            ((Range)ws.Cells[headingRow + 5, 16]).FormulaR1C1 = string.Format("=MAX(MAX(R{0}C[{2}]:R{1}C[{2}]),ABS(MIN(R{0}C[{2}]:R{1}C[{2}])))", startRow + 1, startRow + m_athEq.Count - 1, -11);

            for (int i = 3; i <= 5; i++)
            {
                ((Range)ws.Cells[headingRow + i, 16]).Style = "Output";
            }

            // Arias Intensity
            ((Range)ws.Cells[headingRow + 6, 15]).Value2 = "Arias Intensity (m/s)";
            ((Range)ws.Cells[headingRow + 6, 16]).FormulaR1C1 = string.Format("=SUM(R[-8]C[5]:R[{0}]C[5])*PI()/(2*9.81)", m_athEq.Count - 10);
            ((Range)ws.Cells[headingRow + 6, 16]).Style = "Calculation";

            // Predominant Period
            ws.Cells[headingRow + 7, 15] = "Predominant Period (s)";
            ws.Cells[headingRow + 7, 16] = this.Options.MyFourierSpectraMaker.PredominantPeriod;
            ((Range)ws.Cells[headingRow + 7, 16]).Style = "Output";

        } // Fill statistics



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
            xAxis.MinimumScale = 0.0;
            xAxis.MaximumScale = this.Options.MyResponseSpectraMaker.Options.XaxisMaxScale;

            Axis yAxis = (Axis)xlChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary);
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = "Acceleration (g)";

            // Add title:
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = "Response Spectrum";
            xlChart.Legend.Position = XlLegendPosition.xlLegendPositionTop;

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
                seriesCollection.Item(1).XValues = string.Format("={0}!$A{1}:$A{2}", ws.Name, startRow, MyEqData.ATH.Count);
                seriesCollection.Item(1).Values = string.Format("={0}!$B{1}:$B{2}", ws.Name, startRow, MyEqData.ATH.Count);

                seriesCollection.NewSeries();
                seriesCollection.Item(2).Name = "Surface";
                seriesCollection.Item(2).XValues = string.Format("={0}!R{1}C8:R{2}C8", ws.Name, startRow, MySiteData.ATH.Count);
                seriesCollection.Item(2).Values = string.Format("={0}!R{1}C9:R{2}C9", ws.Name, startRow, MySiteData.ATH.Count);

                xlChart.ChartType = XlChartType.xlXYScatterLinesNoMarkers;

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
