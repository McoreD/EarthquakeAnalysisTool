using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EqAT.Helpers
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
        public List<string> PeriodList { get; private set; }
        public List<string> FourierAmplitudesList { get; private set; }
        private List<double> FourierAmplitudesList_double { get; set; }
        public FourierASMakerOptions Options { get; private set; }

        public double MaximumAmplitude { get; private set; }
        public double BandwidthStart { get; private set; }
        public double BandwidthFinish { get; private set; }

        public FASMaker(FourierASMakerOptions options)
        {
            this.Options = new FourierASMakerOptions();
            this.Options.XaxisMaxScale = 5.0;

            this.FreqList = new List<string>();
            this.PeriodList = new List<string>();
            this.FourierAmplitudesList = new List<string>();
            this.FourierAmplitudesList_double = new List<double>();

            this.Options = options;
        }

        public void ReadData()
        {
            this.FourierAmplitudesList.Clear();
            this.FreqList.Clear();
            this.PeriodList.Clear();

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
                double readCheck = 0.0;
                double.TryParse(row[1], out readCheck);
                while (IsValidNumberRow(row) && readCheck > 0)
                {
                    row = SplitLineToRow(sr.ReadLine());
                    double.TryParse(row[1], out readCheck);
                    if (IsValidNumberRow(row))
                    {
                        AddData(row);
                    }
                }
            } // read data

            foreach (string s in this.FreqList)
            {
                double f = 0.0;
                double.TryParse(s, out f);
                if (f > 0)
                {
                    this.PeriodList.Add((1.0 / f).ToString());
                }
                else
                {
                    f = 100.0;
                    if (this.FreqList.Count > 1)
                    {
                        double.TryParse(this.FreqList[1], out f);
                    }
                    double p = 1.0 / f;
                    p++;
                    this.PeriodList.Add(p.ToString());
                }
            } // fill period list

            foreach (string s in this.FourierAmplitudesList)
            {
                double a = 0.0;
                double.TryParse(s, out a);
                this.MaximumAmplitude = Math.Max(a, this.MaximumAmplitude);
            } // record maximum amplitude

            double bandwidthThreshold = this.MaximumAmplitude / Math.Sqrt(2.0);
            bool bFirst = false;
            int i = 0;
            foreach (double d in this.FourierAmplitudesList_double)
            {
                double temp = 0.0;

                if (d > bandwidthThreshold)
                {
                    if (!bFirst)
                    {
                        double.TryParse(this.FreqList[i], out temp);
                        this.BandwidthStart = temp;
                        bFirst = true;
                    }
                    else
                    {
                        double.TryParse(this.FreqList[i], out temp);
                        this.BandwidthFinish = temp;
                    }
                }

                i++;
            } // calculate bandwidth

        }

        private void AddData(List<string> row)
        {
            if (row.Count > 0)
            {
                this.AddFreq(row);
                this.AddAmplitude(row);
            }
        }

        private void AddFreq(List<string> row)
        {
            this.FreqList.Add(row[0]);

        }

        private void AddAmplitude(List<string> row)
        {
            this.FourierAmplitudesList.Add(row[1]);
            double a = 0.0;
            double.TryParse(row[1], out a);
            this.FourierAmplitudesList_double.Add(a);
        }

    }
}
