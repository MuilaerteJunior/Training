using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {

            IReader<Apple> appleReader = null;
            IReader<Fruit> fruitReader = appleReader;
            
            
            IWriter<Fruit> appleWriter = null;
            IWriter<Apple> fruitWriter = appleWriter;

        }

    }
    
    //interface IReader<T> { // Assim não funciona
    interface IReader<out T> {//Covariante
        T Read();

        //void Write(T value);//Não funciona porque não é contravariante
    }

    interface IWriter<in T> {//Contravariante
        void Write(T value);
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

