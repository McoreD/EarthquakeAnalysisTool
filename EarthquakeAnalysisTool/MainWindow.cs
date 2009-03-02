using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AccelerationTimeHistoryGen
{
    public partial class MainWindow : Form
    {
        private ATHMaker mAthGen = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (paths.Length >= 1)
            {
                mAthGen = new ATHMaker(paths);
            }
        }

        private void tpATHExcel_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (paths.Length == 1)
            {
                ATHColumnMaker acm = new ATHColumnMaker(paths[0]);
                acm.MakeColumn(8*(int)nudATHCount.Value);
                if (File.Exists(acm.ExcelFilePath))
                {
                    Process.Start(acm.ExcelFilePath);
                }
            }
        }

        private void tpATHExcel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tpATHGen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }




    }
}
