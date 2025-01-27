using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Common
{
    public static class StringExtensions
    {
        public static String SafeString(this string input)
        {
            return input ?? "";
        }

        public static String IsNullReplace(this string input, string newValue)
        {
            return (input.IsNullOrWhiteSpace() ? newValue : input);
        }

        public static String TryTrimAll(this string input)
        {
            return input.SafeString().Trim(' ', '\t');
        }

        public static String TryReplace(this string input, char oldChar, char newChar)
        {
            return (input.IsNullOrWhiteSpace() ? input : input.SafeString().Replace(oldChar, newChar));
        }

        public static String TryReplace(this string input, string oldValue, string newValue)
        {
            return (input.IsNullOrWhiteSpace() ? input : input.SafeString().Replace(oldValue, newValue));
        }

        public static String GetLetterOrDigit(this string input)
        {
            StringBuilder sb = new();

            foreach (char x in input.SafeString().Where(x => Char.IsLetterOrDigit(x) || Char.IsWhiteSpace(x)))
            {
                sb.Append(x);
            }

            return sb.ToString();
        }

        public static List<String> TryChunk(this string input, int chunkSize)
        {
            input = input.SafeString();

            List<String> tempList = [];
            for (int i = 0; i < input.Length; i += chunkSize)
            {
                tempList.Add(input.Substring(i, Math.Min(chunkSize, input.Length - i)));
            }

            return tempList;
        }

        public static Boolean IsNullOrWhiteSpace(this string input)
        {
            return String.IsNullOrEmpty((input ?? "").Trim());
        }

        public static Boolean IsNullOrEmpty(this string[] input)
        {
            return (input == null || input.Count() == 0);
        }
    }

    public static class ParseExtensions
    {
        public static String? TryParseBlankStringAsNull(this string input)
        {
            if (input.IsNullOrWhiteSpace()) return null;

            return input;
        }

        public static Boolean TryParseBoolean(this string input)
        {
            Boolean? output = null;

            if (Boolean.TryParse(input, out Boolean temp))
            {
                output = temp;
            }

            return output ?? false;
        }

        public static Boolean? TryParseNullableBoolean(this string input)
        {
            Boolean? output = null;

            if (Boolean.TryParse(input, out Boolean temp))
            {
                output = temp;
            }

            return output;
        }

        public static int? TryParseNullableInt(this string input)
        {
            int? output = null;

            if (int.TryParse(input, out int temp))
            {
                output = temp;
            }

            return output;
        }

        public static double? TryParseNullableDouble(this string input)
        {
            double? output = null;

            if (double.TryParse(input, out double temp))
            {
                output = temp;
            }

            return output;
        }

        public static decimal? TryParseNullableDecimal(this string input)
        {
            decimal? output = null;

            if (decimal.TryParse(input, out decimal temp))
            {
                output = temp;
            }

            return output;
        }

        public static DateTime? TryParseNullableDateTime(this string input)
        {
            DateTime? output = null;

            DateTime temp = DateTime.Now;
            if (DateTime.TryParse(input, out temp))
            {
                output = temp;
            }

            return output;
        }
    }
}
