using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame20190201
{
    public class Class1
    {
    }

    public static class MyExtensions
    {
        public static IEnumerable<T> EvenOddSwap <T>(this IEnumerable<T> s)
        {
            if (s == null)
                throw new ArgumentNullException();

            var en = s.GetEnumerator();
        }
    }
}
