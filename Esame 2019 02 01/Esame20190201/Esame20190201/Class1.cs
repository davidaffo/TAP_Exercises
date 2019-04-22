using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Esame20190201
{

    public static class MyExtensions
    {
        public static IEnumerable<T> EvenOddSwap <T>(this IEnumerable<T> s)
        {
            if (s == null)
                throw new ArgumentNullException();

            var now = s.GetEnumerator();
            now.Reset();
            var future = s.GetEnumerator();
            if (!future.MoveNext())
                return s;
            var resultList = new List<T>();

            do
            {
                //swap
                resultList.Add(future.Current);
                resultList.Add(now.Current);

                //jump 2
                now.MoveNext();
                if (!future.MoveNext())
                    return resultList;
                now.MoveNext();
            } while (future.MoveNext());

            return resultList;

        }
    }

    [TestFixture]
    public class MyTest
    {
        [Test]
        public void Null_sequence_throws()
        {
            List<int> s = null;
            Assert.That(() => s.EvenOddSwap(), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void List_swap_returns()
        {
            var s = new List<string>() { "Donald Duck", "Louie", "Dewey", "Huey", "Scrooge McDuck" };
            var expected = new List<string>() { "Louie", "Donald Duck", "Huey", "Dewey", "Scrooge McDuck" };
            Assert.That(s.EvenOddSwap(), Is.EqualTo(expected));
        }
    }
}
