using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Business
    {
        private static string[] _below20 ={
            "zero", "one", "two", "three","four", "five",
            "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen" };

        private static string[] _tens =
            { "zero", "ten", "twenty", "thirty", "forty","fifty", "sixty", "seventy", "eighty", "ninety" };

        public string ConvertToWord(string input)
        {
            string result = "";

            if (!RangeIsValid(input))
                result = "Out of Range Error![0-999999999,99]";
            else
            {
                input = input.Replace(".", ",");

                int intPart = GetIntPart(input);
                int decimalPart = GetDecimalPart(input);

                result += IntToPostfixedWord(intPart, "dollar");

                if (decimalPart > 0)
                    result += $" and {IntToPostfixedWord(decimalPart, "cent")}";
            }

            return result;
        }

        private bool RangeIsValid(string input) 
            => double.TryParse(input.Replace(",", "."), out double dValue) 
                && dValue < 1000000000;

        public int GetIntPart(string input)
            => Convert.ToInt32(
                (input.Contains(","))
                ? input.Substring(0, input.IndexOf(","))
                : input);

        public int GetDecimalPart(string input)
        {
            string str = "0";

            input = input.TrimEnd(new char[] { ','});

            if (input.Contains(","))
                str = input.Substring(input.IndexOf(",") + 1);

            int result = Convert.ToInt32(str);
            return str.Length == 1 ? result * 10 : result;
        }
        
        public string IntToPostfixedWord(int number, string postFix)
        {
            var res = $"{IntToWord(number)} {postFix}";
            return number == 1 ? res : res + "s";
        }

        public string IntToWord(int intPart)
        {
            int belowThousandPart = intPart % 1000;
            intPart /= 1000;
            int thousandPart = intPart % 1000;
            intPart /= 1000;
            int millionPart = intPart % 1000;

            IList<string> strParts = new List<string>();
            if (millionPart > 0)
                strParts.Add($"{getBelow1000(millionPart)} million");

            if (thousandPart > 0)
                strParts.Add($"{getBelow1000(thousandPart)} thousand");

            if (belowThousandPart > 0 || (millionPart == 0 && thousandPart == 0))
                strParts.Add($"{getBelow1000(belowThousandPart)}");

            return String.Join(" ", strParts);
        }

        private string getBelow1000(int intPart)
        {
            string result;
            if (intPart < 100)
                result = getBelow100(intPart);
            else
                result = $"{_below20[intPart / 100]} hundred"
                + (intPart % 100 != 0 ? $" {getBelow100(intPart % 100)}" : "");
            return result;
        }

        public string getBelow100(int intPart)
        {
            string result;
            if (intPart < 20)
                result = getBelow20(intPart);
            else
                result = _tens[intPart / 10]
                    + (intPart % 10 != 0 ? $"-{getBelow20(intPart % 10)}" : "");

            return result;
        }

        public string getBelow20(int intPart) => _below20[intPart];

    }
}
