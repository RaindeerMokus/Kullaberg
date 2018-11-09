using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekDay
{
    static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> ts)
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
