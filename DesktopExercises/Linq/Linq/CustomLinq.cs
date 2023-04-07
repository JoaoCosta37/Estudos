using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static  class CustomLinq
    {

       // public delegate bool Condition<T>(T value);
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T,bool> condition)
        {
            List<T> values = new List<T>();

            foreach(var item in source)
            {
                if (condition(item))
                    values.Add(item);
            }


            return values;
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {

            foreach(T s in source)
            {
                if (condition(s))
                {
                    return s;
                }
            }

            throw new Exception("Não achou o elemento...");
        }

        public static T FistOrDefault<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            foreach(var s in source)
            {
                if (condition(s))
                {
                    return s;
                }

            }

            return default(T);
        }
    }
}
