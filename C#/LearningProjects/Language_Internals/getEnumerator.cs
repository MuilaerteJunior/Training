using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {
            foreach ( int x in new MyCollection() ) {
                Console.WriteLine(x);
            }

        }
    }

    class MyCollection {
        public MyEnumerator GetEnumerator() {
            return new MyEnumerator();
        }
    }

    class MyEnumerator {
        public bool MoveNext() {
            return true;
        }

        public object Current {

            get {
                return 42;
            }
        }
    }
}
