using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace.Implementation
{
    public class Replace
    {
        public static IEnumerable<T> MacroExpansion<T>(IEnumerable<T> sequence, T values, IEnumerable<T> newValues)
        {
            CheckNotNull(sequence, nameof(sequence));
            CheckNotNull(newValues,nameof(newValues));
            foreach (var elem in sequence)
            {
                if (Equals(elem, values))
                    foreach (var e in newValues)
                    {
                        yield return e;
                    }
                else yield return elem;
            }
        }
        

        private static void CheckNotNull<T>(IEnumerable<T> parameter, string parameterName)
        {
            if (null == parameter)
            {
            throw new ArgumentNullException(nameof(parameter), " sequence cannot be null");
            }
        }
    }
}
