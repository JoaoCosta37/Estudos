using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringStudies.Converters
{
    public static class ExtensionsToConverter
    {
        public static String[] Inverter(this string str1, string str2)
        {
            str1 = String.Concat(str1,str2);
            str2 = str1.Substring(0, str1.Length - str2.Length);
            str1 = str1.Substring(str2.Length);

            return new string[] { str1, str2 };
        }
        public static string Captalize(this string text)
        {
            string result = "";
            foreach (var token in text.Split(" "))
            {
                var lower = token.ToLower();
                lower = Char.ToUpper(lower[0]) + lower.Substring(1);

                result += lower + " ";
            }
            return result;
        }
    }
}
