using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AccelerationTimeHistoryGen
{
    public partial class Form1 : Form
    {
        private cAthGen mAthGen = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            if (paths.Length >= 1)
            {
                mAthGen = new cAthGen(paths);
            }
        }


        private void Form1_DragEnter(object sender, DragEventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
