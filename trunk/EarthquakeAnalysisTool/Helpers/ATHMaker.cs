using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using THTool.Properties;
using System.Globalization;

namespace THTool
{
    public class ATHMakerOptions
    {
        public bool LimitTo4000Readings { get; set; }
        public string[] Files { get; set; }
    }

    /// <summary>
    /// Creates a Shake91 compatible input file from a list of accelerations (experimental)
    /// </summary>
    class ATHMaker
    {
        public ATHMakerOptions Options { get; private set; }
        private List<StringBuilder> mOutputs = new List<StringBuilder>();

        public ATHMaker(ATHMakerOptions options)
        {
            this.Options = options;
            sMakeFiles();

        }

        public void sMakeFiles()
        {
            foreach (string f in this.Options.Files)
            {
                StringBuilder sbFile = new StringBuilder();
                sbFile.AppendLine("PEER STRONG MOTION DATABASE RECORD. PROCESSING BY MIKE DELPACH.");
                sbFile.AppendLine("IMPERIAL VALLEY 5/19/40 0439, EL CENTRO ARRAY #9, 180 (USGS STATION 117)");
                sbFile.AppendLine(string.Format("ACCELERATION TIME HISTORY IN UNITS OF G. FILTER POINTS: HP={0} Hz LP={1} Hz",
                    Settings.Default.HP, Settings.Default.LP));

                int lNPTS = 0;
                StringBuilder sbAcc = new StringBuilder();
                List<double> lNum = new List<double>();

                using (StreamReader sr = new StreamReader(f))
                {
                    while (!sr.EndOfStream)
                    {
                        double acc = 0;
                        string l = sr.ReadLine().Replace("", "");
                        if (!string.IsNullOrEmpty(l))
                        {
                            if (Double.TryParse(l, out acc))
                            {
                                lNum.Add(acc);
                            }
                            else
                            {
                                Console.WriteLine(l);
                                throw new Exception("Could not parse line...");
                            }
                        }
                    }
                }

                int max = (this.Options.LimitTo4000Readings ? 4000 : lNum.Count);
                int col = 0;

                for (int i = 0; i < max; i++)
                {
                    double acc = lNum[i];

                    string gap = "  ";
                    // determine the first gap
                    if (lNum.Count > 0 && lNum.Count > lNPTS)
                    {
                        // second or later number
                        if (lNum[lNPTS] >= 0.0)
                        {
                            gap = "   ";
                        }
                    }
                    else
                    {
                        // first number
                        if (acc > 0.0)
                        {
                            gap = "   ";
                        }
                    }

                    sbAcc.Append(gap);
                    sbAcc.Append(String.Format(new SciFormat(), "{0:H}", acc));
                    lNPTS++;
                    col++;

                    if (col < 5)
                    {
                        // sbAcc.Append(gap);
                    }
                    else
                    {
                        sbAcc.AppendLine();
                        col = 0;
                    }
                }

                sbFile.AppendLine(string.Format("NPTS=  {0}, DT= {1} SEC", lNPTS, Settings.Default.DT));
                sbFile.AppendLine(sbAcc.ToString().TrimEnd());

                //string r = Path.Combine(Path.GetDirectoryName(f), "diam.acc");

                string r = Path.Combine(Path.Combine(Path.GetDirectoryName(f), Path.GetFileName(f) + "-data"), "diam.acc");

                if (!Directory.Exists(Path.GetDirectoryName(r)))
                {

                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(r));
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                using (StreamWriter sw = new StreamWriter(r))
                {
                    sw.WriteLine(sbFile.ToString());
                }
            }

        }

    }
}
