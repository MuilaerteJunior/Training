using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {

        static void Main() {
            foreach ( var x in new[] { 2, 3, 5, 7 } ) {
                new Thread(() => Console.WriteLine(x)).Start();
            }

            Console.Read();
        }

    }
}
