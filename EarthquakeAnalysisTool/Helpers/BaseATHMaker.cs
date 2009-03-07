using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using THTool.Helpers;

namespace THTool
{
    /// <summary>
    /// Reads Shake91 input file and generates an accelerogram in Excel
    /// </summary>
    class BaseATHMaker : THProcessor
    {
        private string mPath;
        /// <summary>
        /// Acceleration Time Histories
        /// </summary>
        public List<string> ATH { get; private set; }
        private int NTPS;
        private decimal mDT;
        public string Title { get; private set; }

        public BaseATHMaker(string fp)
        {
            ATH = new List<string>();
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
                ATH.Clear();
                string line = sr.ReadLine();
                this.Title = sr.ReadLine(); // Title
                line = sr.ReadLine();
                line = sr.ReadLine(); // NPTS=  5366, DT= .00500 SEC
                RemoveDoubleSpaces(ref line);
                GroupCollection gc = Regex.Match(line, "NPTS= (?<NTPS>.+), DT= (?<DT>.+) SEC").Groups;
                int.TryParse(gc[1].Value, out this.NTPS);
                decimal.TryParse(gc[2].Value, out this.mDT);
                if (this.mDT == 0)
                    throw new Exception("DT is Zero");

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    RemoveDoubleSpaces(ref line);
                    foreach (string s in SplitLine(line))
                    {
                        ATH.Add(s);
                        if (ATH.Count == NTPS)
                        {
                            return ATH;
                        }
                    }
                }

            }


            return ATH;
        }


    }
}
