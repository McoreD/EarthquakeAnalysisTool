using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace AccelerationTimeHistoryGen.Helpers
{
    class ExcelReporter
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
        private Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private Microsoft.Office.Interop.Excel.Sheets mWorkSheets;

        public string ExcelFilePath { get; set; }

        private string mXlsFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "data.xlsx");

        private Microsoft.Office.Interop.Excel.Worksheet mWSheet1 = new Microsoft.Office.Interop.Excel.WorksheetClass();

        public Microsoft.Office.Interop.Excel.Worksheet WorkSheet1
        {
            get { return mWSheet1; }
        }

        /// <summary>
        /// Filepath of the Excel Report file
        /// </summary>
        /// <param name="fp"></param>
        public ExcelReporter(string fp)
        {
            this.mPath = fp;
        }

        /// <summary>
        /// Export ATH to Excel
        /// </summary>
        public void CreateReport()
        {
            //************************
            //* Initialize Worksheets
            //************************

            mExcelApp.DisplayAlerts = false;
            mWorkBook = mExcelApp.Workbooks.Open(mXlsFilePath, 0, false, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            mWorkSheets = mWorkBook.Worksheets;
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");

            FillSurfaceATHData(mWSheet1);
            FillBaseATHData(mWSheet1);

            GenerateChart(mWSheet1);

            AutofitColumns(mWSheet1, "A1", "N1");

            string ext = Path.GetExtension(mPath);

            if (ext.ToLower().Equals(".xlsx"))
            {
                ExcelFilePath = SaveAs2007(mPath);
            }
            else if (ext.ToLower().Equals(".xls"))
            {
                ExcelFilePath = SaveAs2003(mPath);
            }

            mExcelApp.Quit();

        }

        private void FillBaseATHData(Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            List<string> acc = MyBaseATHMaker.ReadATH();
            int dt = MyBaseATHMaker.DT;

            for (int i = 0; i < acc.Count; i++)
            {
                ws.Cells[i + 1, 4] = (decimal)(i * dt / 1000.0);
                ws.Cells[i + 1, 5] = acc[i];
            }
        }

        private void FillSurfaceATHData(Microsoft.Office.Interop.Excel.Worksheet ws)
        {
            List<string> acc = MySurfaceATHMaker.ReadATH();
            int dt = MySurfaceATHMaker.DT;

            for (int i = 0; i < acc.Count; i++)
            {
                ws.Cells[i + 1, 1] = (decimal)(i * dt / 1000.0);
                ws.Cells[i + 1, 2] = acc[i];
            }
        }

 

        private void GenerateChart(Worksheet ws)
        {
            try
            {
                // Now create the chart.
                ChartObjects chartObjs = (ChartObjects)ws.ChartObjects(Type.Missing);
                ChartObject chartObj = chartObjs.Add(100, 20, 960, 540);
                Chart xlChart = chartObj.Chart;

                SeriesCollection seriesCollection = (SeriesCollection)xlChart.SeriesCollection(Type.Missing);
                seriesCollection.NewSeries();
                seriesCollection.Item(1).XValues = "=Sheet1!$A:$A";
                seriesCollection.Item(1).Values = "=Sheet1!$B:$B";
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
                xlChart.HasLegend = false;
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

            mExcelApp.DisplayAlerts = true;

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

            mExcelApp.DisplayAlerts = true;

            return filePath;
        }

        public string SaveAs2007(string dir, string fileName)
        {
            return (Path.Combine(dir, fileName + ".xlsx"));
        }

        private void AutofitColumns(Worksheet ws, string colStart, string colFinish)
        {
            //AutoFit columns A:D.
            Microsoft.Office.Interop.Excel.Range oRng;
            oRng = ws.get_Range(colStart, colFinish);
            oRng.EntireColumn.AutoFit();
        }
    }
}
