using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_20190117
{
    public class Es3
    {


        public class Client1
        {
            public ILib0 MyLib0 { get; }

            public Client1(ILib0Factory factory)
            {
                MyLib0 = factory.CreateNew();
            }

            public ILib0 CM(ILib0Factory factory)
            {
                var x = factory.CreateNew();
                x.I++;
                return x;
            }
        }
        public interface ILib0
        {
            int I { get; set; }
        }
        public class Lib0 : ILib0
        {
            public int I { get; set; }
            public Lib0(ILiB1 liB1) { I = liB1.M1(); }
        }
        public interface ILiB1
        {
            int M1();
        }
        public class Lib1 : ILiB1
        {
            public int M1() { return 42; }
        }
        public interface ILib0Factory
        {
            ILib0 CreateNew();
        }
        public class Lib0Factory : ILib0Factory
        {
            public ILib0 CreateNew()
            {
                var lib = new Lib1Factory();
                return new Lib0(lib.CreateNew());
            }
        }
        public class Lib1Factory
        {
            public ILiB1 CreateNew()
            {
                return new Lib1();
            }
        }
    }
}
