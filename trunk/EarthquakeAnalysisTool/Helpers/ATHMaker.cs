using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AccelerationTimeHistoryGen.Properties;
using System.Globalization;

namespace AccelerationTimeHistoryGen
{
    /// <summary>
    /// Creates a Shake91 compatible input file from a list of accelerations (experimental)
    /// </summary>
    class ATHMaker
    {
        private List<string> mFiles = new List<string>();
        private List<StringBuilder> mOutputs = new List<StringBuilder>();

        public ATHMaker(string[] files)
        {
            foreach (string f in files)
            {
                if (File.Exists(f))
                {
                    mFiles.Add(f);
                }
            }

            sMakeFiles();

        }

        public void sMakeFiles()
        {
            foreach (string f in mFiles)
            {
                StringBuilder sbFile = new StringBuilder();
                sbFile.AppendLine("PEER STRONG MOTION DATABASE RECORD. PROCESSING BY MIHAJLO DELPOVIC.");
                sbFile.AppendLine("IMPERIAL VALLEY 5/19/40 0439, EL CENTRO ARRAY #9, 180 (USGS STATION 117)");
                sbFile.AppendLine(string.Format("ACCELERATION TIME HISTORY IN UNITS OF G. FILTER POINTS: HP={0} Hz LP={1} Hz",
                    Settings.Default.HP, Settings.Default.LP));

                int lNPTS = 0;
                StringBuilder sbAcc = new StringBuilder();
                List<double> lNum = new List<double>();

                using (StreamReader sr = new StreamReader(f))
                {

                    NumberFormatInfo info = new NumberFormatInfo();
                    int col = 0;
                    while (!sr.EndOfStream)
                    {
                        double acc = 0;
                        string l = sr.ReadLine().Replace("", ""); //"0.140539E-03";

                        if (!string.IsNullOrEmpty(l))
                        {
                            if (Double.TryParse(l, NumberStyles.Float, info, out acc))
                            {

                                l = String.Format(new SciFormat(), "{0:H}", acc);

                                lNum.Add(acc);
                                //l = string.Format("{0:e}", acc);
                                //Console.WriteLine(l);
                                //l = l.Replace("e-00", "E-0");
                                //l = l.Replace("e+00", "E+0");


                            }
                            else
                            {
                                Console.WriteLine(l);
                            }

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

                            if (!string.Equals("", l))
                            {
                                sbAcc.Append(gap);
                                sbAcc.Append(l);
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

                        }
                    }

                    sbFile.AppendLine(string.Format("NPTS=  {0}, DT= {1} SEC", lNPTS, Settings.Default.DT));
                    sbFile.AppendLine(sbAcc.ToString().TrimEnd());
                }

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
