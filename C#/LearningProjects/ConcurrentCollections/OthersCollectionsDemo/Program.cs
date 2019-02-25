using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections.OthersCollectionsDemo {
    class Program {
        static void Main(string[] args) {
            //UsingQueue();

            //UsingConcurrentQueue();

            //UsingConcurrentStack();

            //UsingConcurrentBag();

            UsingIProducerConsumerCollection();
        }

        private static void UsingIProducerConsumerCollection() {
            IProducerConsumerCollection<string> shirts = new ConcurrentBag<string>();
            shirts.TryAdd("Pluralsight");
            shirts.TryAdd("Wordpress");
            shirts.TryAdd("Code school");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1;
            bool success = shirts.TryTake(out item1);

            if ( success )
                Console.WriteLine("\r\nRemoving: " + item1);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach ( var item in shirts ) {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }

        /// <summary>
        /// A concurrent Bag no guarantee the order of items inside it.
        /// </summary>
        private static void UsingConcurrentBag() {
            var shirts = new ConcurrentBag<string>();
            shirts.Add("Pluralsight");
            shirts.Add("Wordpress");
            shirts.Add("Code school");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1;
            bool success = shirts.TryTake(out item1);

            if ( success )
                Console.WriteLine("\r\nRemoving: " + item1);
            else
                Console.WriteLine("queue was empty");

            string item2;
            bool success2 = shirts.TryPeek(out item2);

            if ( success2 )
                Console.WriteLine("\r\nPeeking: " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach ( var item in shirts ) {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }

        /// <summary>
        /// Concurrent Stack uses LIFO
        /// LIFO => Last In, First Out
        /// </summary>
        private static void UsingConcurrentStack() {
            var shirts = new ConcurrentStack<string>();
            shirts.Push("Pluralsight");
            shirts.Push("Wordpress");
            shirts.Push("Code school");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1;
            bool success = shirts.TryPop(out item1);

            if ( success )
                Console.WriteLine("\r\nRemoving: " + item1);
            else
                Console.WriteLine("queue was empty");

            string item2;
            bool success2 = shirts.TryPeek(out item2);

            if ( success2 )
                Console.WriteLine("\r\nPeeking: " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach ( var item in shirts ) {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }


        /// <summary>
        /// FIFO EXAMPLE, First in, first out!
        /// </summary>
        /// <param name="args"></param>
        private static void UsingConcurrentQueue() {
            var shirts = new ConcurrentQueue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("Wordpress");
            shirts.Enqueue("Code school");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1;
            bool success = shirts.TryDequeue(out item1);

            if ( success )
                Console.WriteLine("\r\nRemoving: " + item1);
            else
                Console.WriteLine("queue was empty");

            string item2;
            bool success2 = shirts.TryPeek(out item2);

            if ( success2 )
                Console.WriteLine("\r\nPeeking: " + item2);
            else
                Console.WriteLine("queue was empty");

            Console.WriteLine("\r\nEnumerating:");
            foreach ( var item in shirts ) {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }

        /// <summary>
        /// FIFO EXAMPLE, First in, first out!
        /// </summary>
        /// <param name="args"></param>
        private static void UsingQueue() {
            var shirts = new Queue<string>();
            shirts.Enqueue("Pluralsight");
            shirts.Enqueue("Wordpress");
            shirts.Enqueue("Code school");

            Console.WriteLine("After enqueuing, count = " + shirts.Count.ToString());

            string item1 = shirts.Dequeue();
            Console.WriteLine("\r\nRemoving " + item1);

            string item2 = shirts.Peek();
            Console.WriteLine("\r\nPeeking " + item2);

            Console.WriteLine("\r\nEnumerating:");
            foreach ( var item in shirts ) {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nAfter enumerating, count = " + shirts.Count.ToString());
        }
    }
}
