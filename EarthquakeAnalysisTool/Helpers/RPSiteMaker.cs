using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace THTool.Helpers
{
    /// <summary>
    /// Optoins for RPSiteMaker
    /// </summary>
    public class RPSiteMakerOptions
    {
        public string FilePath { get; set; }
        public double XaxisMaxScale { get; set; }
    }

    /// <summary>
    /// Class reponsible for generating Response Spectrum from Shake91 data
    /// </summary>
    public class RPSiteMaker : FileProcessor
    {
        public List<string> PeriodList { get; private set; }
        public List<string> ATH { get; private set; }
        public RPSiteMakerOptions Options { get; private set; }
        private int ValidColumnCount = 8;

        public RPSiteMaker(RPSiteMakerOptions options)
        {
            this.Options = new RPSiteMakerOptions();
            this.Options.XaxisMaxScale = 5.0;

            this.PeriodList = new List<string>();
            this.ATH = new List<string>();
            this.Options = options;
        }

        public void ReadData()
        {
            this.ATH.Clear();
            this.PeriodList.Clear(); 

            using (StreamReader sr = new StreamReader(this.Options.FilePath))
            {
                string line = sr.ReadLine();
                while (!line.Contains("Acceleration of gravity used"))
                {
                    line = sr.ReadLine();
                }
                // line is [Acceleration of gravity used =   32.18] 
                line = sr.ReadLine(); // GRB; input:Diam @ .1g         DAMPING RATIO = 0.05
                line = sr.ReadLine(); // NO.    PERIOD     REL. DISP.      REL. VEL.   PSU.REL.VEL.      ABS. ACC.   PSU.ABS.ACC.     FREQ.
                line = sr.ReadLine(); // 1      0.01        0.00001        0.00013        0.00460        0.09000        0.08975    100.00
                List<string> row = SplitLineToRow(line);
                AddData(row);

                while (IsValidNumberRow(row))
                {
                    row = SplitLineToRow(sr.ReadLine());
                    if (IsValidNumberRow(row))
                    {
                        AddData(row);
                    }
                }
            }
        }



        private void AddData(List<string> row)
        {
            this.AddPeriod(row);
            this.AddAccel(row);
        }

        private void AddPeriod(List<string> row)
        {
            this.PeriodList.Add(row[1]);
        }

        private void AddAccel(List<string> row)
        {
            this.ATH.Add(row[5]);
        }

    }
}
