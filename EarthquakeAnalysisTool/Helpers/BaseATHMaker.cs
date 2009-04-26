using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using EqAT.Helpers;

namespace EqAT
{
    /// <summary>
    /// Reads Shake91 input file and generates an accelerogram in Excel
    /// </summary>
    public class BaseATHMaker : FileProcessor
    {
        private string mPath;
        /// <summary>
        /// Acceleration Time Histories
        /// </summary>
        public List<string> ATH { get; private set; }
        private int NTPS;
        private decimal mDT;

        public BaseATHMaker(string fp)
        {
            ATH = new List<string>();
            this.mPath = fp;
        }

        public int DT { get { return (int)(mDT * 1000); } private set { ; } }

        public List<string> ReadATH()
        {
            using (StreamReader sr = new StreamReader(mPath))
            {
                this.ATH.Clear();
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
                    foreach (string s in SplitLineToRow(line))
                    {
                        this.ATH.Add(s);
                        if (ATH.Count == NTPS)
                        {
                            return this.ATH;
                        }
                    }
                }

            }

            return this.ATH;
        }


    }
}
