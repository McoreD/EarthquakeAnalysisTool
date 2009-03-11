using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace THTool.Helpers
{
    public class FileProcessor
    {
        public string Title { get; protected set; }

        protected void RemoveDoubleSpaces(ref string line)
        {
            line = line.Trim();
            while (line.Contains("  "))
            {
                line = Regex.Replace(line, "  ", " ");
            }
        }

        /// <summary>
        /// Removes Double Spaces and Splits the Line by Space in to multiple Columns
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected List<string> SplitLineToRow(string line)
        {
            this.RemoveDoubleSpaces(ref line);
            List<string> acc = new List<string>();
            string[] nums = Regex.Split(line, " ");
            foreach (string s in nums)
            {
                acc.Add(s);
            }
            return acc;
        }

        protected bool IsValidNumberRow(List<string> row)
        {
            foreach (string s in row)
            {
                try
                {
                    double test = double.Parse(s);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        protected bool IsValidRow(string line, int valCount)
        {
            return SplitLineToRow(line).Count > valCount;
        }

    }
}
