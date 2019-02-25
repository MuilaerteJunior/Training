using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main() {
            var b1 = new Bar<int>();
            var b2 = new Bar<string>();
            var b3 = new Bar<AppDomain>();
            Console.ReadLine();

            GC.KeepAlive(b1);
            GC.KeepAlive(b2);
            GC.KeepAlive(b3);
        }
    }

    class Bar<T> {
        int x;
        T value;
        bool b;
    }
}

