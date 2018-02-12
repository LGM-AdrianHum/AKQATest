// File: ChequeTest/ChequeTest/CurrencyHelper.cs
// User: Adrian Hum/
// 
// Created:  2018-02-12 9:13 AM
// Modified: 2018-02-12 9:26 AM

using System;
using System.Text;

namespace TestApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class CurrencyHelper
    {
        public static string NumberToWords(decimal number)
        {
            var num1 = Convert.ToInt32(Math.Truncate(number));
            var num2 = Convert.ToInt32((number - Math.Truncate(number)) * 100);
            var sb = new StringBuilder(NumberToWords(num1));
            sb.Append(num1 == 1 ? " dollar" : " dollars");
            sb.Append(" and ");
            sb.Append(NumberToWords(num2));
            sb.Append(num2 == 1 ? " cent" : " cents");
            return sb.ToString().ToUpperInvariant();
        }

        public static string NumberToWords(int number)
        {
            try
            {
                if (number == 0)
                    return "zero";

                if (number < 0)
                    return "minus " + NumberToWords(Math.Abs(number));

                var words = new StringBuilder();

                if (number / 1000000 > 0)
                {
                    words.AppendFormat("{0} million ", NumberToWords(number / 1000000));
                    number %= 1000000;
                }

                if (number / 1000 > 0)
                {
                    words.AppendFormat("{0} thousand ", NumberToWords(number / 1000));
                    number %= 1000;
                }

                if (number / 100 > 0)
                {
                    words.AppendFormat("{0} hundred ", NumberToWords(number / 100));
                    number %= 100;
                }


                if (number <= 0) return words.ToString();
                if (words.Length > 0) words.Append("and ");

                var unitsMap = new[]
                {
                    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
                    "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                };
                var tensMap = new[]
                    {"zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

                if (number < 20)
                {
                    words.Append(unitsMap[number]);
                }
                else
                {
                    words.Append(tensMap[number / 10]);
                    if (number % 10 > 0) words.AppendFormat("-{0}", unitsMap[number % 10]);
                }

                return words.ToString();
            }
            catch (Exception ex)
            {
                //Under usual circumstances, I would have used logging and floated the exception back to the controller.
                return ex.Message;
            }
        }
    }
}