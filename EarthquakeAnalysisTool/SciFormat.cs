using System;
using System.Collections.Generic;
using System.Text;

namespace THTool
{
    public class SciFormat : IFormatProvider, ICustomFormatter
    {
        private const int ACCT_LENGTH = 12;

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            // Convert argument to a string.
            double num = double.Parse(arg.ToString());

            //// If account number is less than 12 characters, pad with leading zeroes.
            //if (result.Length < ACCT_LENGTH)
            //    result = result.PadLeft(ACCT_LENGTH, '0');
            //// If account number is more than 12 characters, truncate to 12 characters.
            //if (result.Length > ACCT_LENGTH)
            //    result = result.Substring(0, ACCT_LENGTH);

            string result = string.Format("{0:E6}", num);

            if (num >= 0)
            {
                result = result.Remove(1, 1).Insert(0, ".");
            }
            else
            {
                result = result.Remove(2, 1).Insert(1, ".");
            }
            string n = result.Split('E')[0];
            int pow = int.Parse(result.Split('E')[1]) + 1;
            string sign = (pow >= 0 ? "+" : "-");
            string sPow = string.Format("E{0}{1}", sign, Math.Abs(pow).ToString("00"));
            result = n + sPow;


            return result;

            //// Support G and H format specifiers.
            //if (String.IsNullOrEmpty(fmt))
            //    fmt = "G";

            //if (fmt.ToUpper() == "G")
            //    return result;
            //// Add hyphens for H format specifier.
            //else if (fmt.ToUpper() == "H")
            //    return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
            //// Return string representation of argument for any other formatting code.
            //else
            //    throw new FormatException(String.Format("{0} is not a valid format string.", fmt));
        }
    }


}
