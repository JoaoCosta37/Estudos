using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class Last
    {
        public static T LastItem<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            T result = default(T);
            bool found = false;
            foreach(var s in source)
            {
                if (condition(s))
                {
                    found = true;
                    result = s;
                }
            }
            if (found)
            {
                return result;
            }
            throw new Exception("Não achou...");
        }
    }
}
