using System;

namespace Language_Internals {
    class Program {
        static void Main() {

        }

        static void Food(int a, int b) {
            if ( a > b )
                Console.WriteLine(">");
            else if ( a < b )
                Console.WriteLine("<");
            else
                Console.WriteLine("=");
        }

    }
}
