using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace THTool.Helpers
{
    /// <summary>
    /// Optoins for RPSiteMaker
    /// </summary>
    public class FourierASMakerOptions
    {
        public string FilePath { get; set; }
        public double XaxisMaxScale { get; set; }
    }

    /// <summary>
    /// Class reponsible for generating Response Spectrum from Shake91 data
    /// </summary>
    public class FASMaker : FileProcessor
    {
        public List<string> FreqList { get; private set; }
        public List<string> FourierAmplitudesList { get; private set; }
        public FourierASMakerOptions Options { get; private set; }

        public FASMaker(FourierASMakerOptions options)
        {
            this.Options = new FourierASMakerOptions();
            this.Options.XaxisMaxScale = 5.0;

            this.FreqList = new List<string>();
            this.FourierAmplitudesList = new List<string>();
            this.Options = options;
        }

        public void ReadData()
        {
            this.FourierAmplitudesList.Clear();
            this.FreqList.Clear(); 

            using (StreamReader sr = new StreamReader(this.Options.FilePath))
            {
                string line = sr.ReadLine();
                while (!line.Contains("        FREQ       FOURIER AMPLITUDES"))
                {
                    line = sr.ReadLine();
                }
                // line is [Acceleration of gravity used =   32.18] 
                line = sr.ReadLine(); // GRB; input:Diam @ .1g         DAMPING RATIO = 0.05
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
            if (row.Count > 0)
            {
                this.AddPeriod(row);
                this.AddAccel(row);
            }
        }

        private void AddPeriod(List<string> row)
        {
            this.FreqList.Add(row[0]);
        }

        private void AddAccel(List<string> row)
        {
            this.FourierAmplitudesList.Add(row[1]);
        }

    }
}
