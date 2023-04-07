using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Linq
{
    public static class StringExtension
    {
        //Right
        //recebe um n do tipo int
        // retorna os últimos n caracteres da string

        public static String Right (this String str, int n)
        {
            var finishStr = str.Substring(str.Length - n);
            return finishStr;
        }

        public static String DeleteLast (this String str, int n)
        {
            var finishStr = str.Substring(0,str.Length - n);
            return finishStr;
        }
        public static String Reverter(this String str)
        {
            Stack<char> chars = new Stack<char>();

            //  List<char> result = new List<char>();
            String result = "";
            foreach(var c in str)
            {
                chars.Push(c);
            }

           for(int i = 0; i < str.Length; i++)
           {
                result += chars.Pop();
           }

           return result;

        }

        public static String Capitalize(this String str)
        {
            String result = "";
            foreach (var token in str.Split(" "))
            {
                var lower = token.ToLower();
                lower = Char.ToUpper(lower[0]) + lower.Substring(1);
              // var teste = str.Select(String.Format);
                 
                result += lower + " ";
            }
            return result;
        }

        public static IEnumerable<TResult> Select<T,TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
        {
            var result = new List<TResult>();
            foreach(var item in enumerable)
            {
                var newItem = func(item);
                result.Add(newItem);
            }
            return result;
        }

        public static int SumIf(this IEnumerable<int> values, Predicate<int> condition)
        {
            int result = 0;
            foreach(var v in values)
            {
                if (condition(v))
                {
                    result += v;
                }
            }
            return result;
        }







    }
}
