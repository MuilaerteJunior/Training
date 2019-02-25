using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Platform {
        static void Main() {
            Console.WriteLine(Environment.Is64BitProcess);
        }
    }
}
