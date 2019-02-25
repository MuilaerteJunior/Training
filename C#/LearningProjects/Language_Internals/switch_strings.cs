using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static int Main(string[] args) {
            switch ( args[0] ) {
                case null: return 0;
                case "bar": return 1;
                case "foo": return 2;
                case "qux": return 3;
                case "baz": return 4;
                case "ham": return 5;
                case "ham1": return 6;
                case "ham2": return 7;
                case "ham3": return 8;
                default: return -1;
            }
        }
    }

}