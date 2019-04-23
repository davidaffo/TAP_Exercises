using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Esame20190201
{

    public static class MyExtensions
    {
        public static IEnumerable<T> EvenOddSwap <T>(this IEnumerable<T> s)
        {
            if (s == null)
                throw new ArgumentNullException();

            var en = s.GetEnumerator();
            if (!en.MoveNext())
                return s;
            var resultList = new List<T>();

            do
            {
                var now = en.Current;
                if (!en.MoveNext())
                {
                    resultList.Add(now);
                    return resultList;
                }
                resultList.Add(en.Current);
                resultList.Add(now);

            } while (en.MoveNext());

            return resultList;

        }
    }

    [TestFixture]
    public class MyTest
    {

        IEnumerable<int> Infinite() //sequenza infinita di numeri interi
        {
            int i = 1;
            while (true)
            {
                yield return i++;
            }
        }

        IEnumerable<int> InfiniteRes(int call) //sequenza infinita di numeri interi
        {
            if (call == 0)
            {
                call++;
                yield return 2;
            }
            if (call == 1)
            {
                call++;
                yield return 1;
            }
            int i = 1;
            int j = 2;
            bool even = false;
            while (true)
            {
                if (even)
                {
                    even = !even;
                    yield return i+=2;
                }
                even = !even;
                yield return j += 2;
            }
        }

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

        [Test]
        public void Infinite_swap_approx_returns([Values(4,10,25,50)] int approx)
        {
            var s = Infinite().Take(approx);
            var expected = InfiniteRes(0).Take(approx);
            Assert.That(s.EvenOddSwap(), Is.EqualTo(expected));
        }
    }
}
