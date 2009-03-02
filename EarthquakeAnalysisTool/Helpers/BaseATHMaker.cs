using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AccelerationTimeHistoryGen
{
    /// <summary>
    /// Reads Shake91 input file and generates an accelerogram in Excel
    /// </summary>
    class BaseATHMaker
    {
        private string mPath;
        /// <summary>
        /// Acceleration Time Histories
        /// </summary>
        private List<string> mATH = new List<string>();
        private int NTPS;
        private decimal mDT;

        public BaseATHMaker(string fp)
        {
            this.mPath = fp;
        }

        public int DT { get { return (int)(mDT * 1000); } private set { ; } }

        private void RemoveDoubleSpaces(ref string line)
        {
            line = line.Trim();
            while (line.Contains("  "))
            {
                line = Regex.Replace(line, "  ", " ");
            }
        }

        private List<string> SplitLine(string line)
        {
            List<string> acc = new List<string>();
            string[] nums = Regex.Split(line, " ");
            foreach (string s in nums)
            {
                acc.Add(s);
            }
            return acc;
        }

        private bool IsValidLine(string line)
        {
            return SplitLine(line).Count > 0;
        }

        public List<string> ReadATH()
        {
            using (StreamReader sr = new StreamReader(mPath))
            {
                mATH.Clear();
                string line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine();
                line = sr.ReadLine(); // NPTS=  5366, DT= .00500 SEC
                GroupCollection gc = Regex.Match(line, "NPTS=  (?<NTPS>.+), DT= (?<DT>.+) SEC").Groups;
                int.TryParse(gc[1].Value, out this.NTPS);
                decimal.TryParse(gc[2].Value, out this.mDT);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    RemoveDoubleSpaces(ref line);
                    foreach (string s in SplitLine(line))
                    {
                        mATH.Add(s);
                        if (mATH.Count == NTPS)
                        {
                            return mATH;
                        }
                    }
                }

            }


            return mATH;
        }


    }
}
