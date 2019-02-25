extern alias Foo1;
extern alias Foo2;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals
{
    class Program {
        static void  Main(string[] args) {
            Foo1::foo.Qux();
            Foo2::foo.Qux();
            Console.ReadKey();
        }
    }
}