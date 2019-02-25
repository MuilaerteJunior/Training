using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main() {
            int c = 2;
            Func<int, int> f = delegate (int x) {
                return x * c;
            };

            c = 4;

            Console.WriteLine(f(3)); //12
        }
    }
}
