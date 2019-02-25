using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {

            Apple[] apples = new[] { new Apple() };
            Fruit[] fruits = apples;

            fruits[0] = new Coconut();//Exception here!
            apples[0].Peel();

        }

    }

    class Fruit {

    }
    class Apple : Fruit {
        public void Peel() { }
    }
    class Coconut: Fruit {
    
        public void Break() { }
    }
}

