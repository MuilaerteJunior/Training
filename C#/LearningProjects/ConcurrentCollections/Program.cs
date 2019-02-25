using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections {
    
    /// <summary>
    /// Existing ConcurrentCollections are:
    ///     - ConcurrentDictionary
    ///     - ConcurrentQueue (Specialized Scenarios only, Produce-consumer scenario)
    ///     - ConcurrentStack (Specialized Scenarios only, Produce-consumer scenario)
    ///     - ConcurrentBag (Specialized Scenarios only, Produce-consumer scenario)
    ///     
    /// For instances (Considering concurrent scenarios): 
    ///     - You can replace a List<T> or T[] with a ConcurrentDictionary<int, T>
    ///     - You can replace a HashSet<T> with a ConcurrentDictionary<T, T>
    ///     - You can replace a SortedList<TKey,TValye>  with a ConcurrentDictionary<TKey,TValue>
    /// </summary>
    class Program {
        static void Main(string[] args) {

            //var orders = new Queue<string>();
            //FirstExample(orders);
            //Task task1 = Task.Run(() => PlaceOrders(orders, "Mui"));
            //Task task2 = Task.Run(() => PlaceOrders(orders, "Thais"));
            //Task.WaitAll(task1, task2);

            var ordersConcurrent = new ConcurrentQueue<string>(); 
            
            Task task3 = Task.Run(() => PlaceOrders(ordersConcurrent, "Mui"));
            Task task4 = Task.Run(() => PlaceOrders(ordersConcurrent, "Thais"));
            Task.WaitAll(task3, task4);

            //Partitioner example: IT may be necessary define how the partitioner will be
            Parallel.ForEach(ordersConcurrent, ProcessOrder);

            foreach ( var order in ordersConcurrent ) {
                Console.WriteLine("ORDER: " + order);
            }

            Console.ReadKey();
        }


        static void ProcessOrder(string order) {

        }

        /// <summary>
        /// First example: using single thread and Queue.
        /// </summary>
        /// <param name="orders"></param>
        private static void FirstExample(Queue<string> orders) {
            PlaceOrders(orders, "Junior");
            PlaceOrders(orders, "Thais");
        }

        /// <summary>
        /// Queues are not guaranteed to be thread safe!!!
        /// So you should use only when running one thread by time
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customerName"></param>
        private static void PlaceOrders(Queue<string> orders, string customerName) {
            for (int i = 0; i < 5; i++ ) {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                orders.Enqueue(orderName);
            }
        }

        /// <summary>
        /// Using lock it's a good choice for smale piece of codes. But it increases a lot
        /// costs of maintenability.
        /// </summary>
        static object _lockObj = new object();
        private static void PlaceOrdersWithLock(Queue<string> orders, string customerName) {
            for (int i = 0; i < 5; i++ ) {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                lock ( _lockObj ) {
                    orders.Enqueue(orderName);
                }
            }
        }
        
        /// <summary>
        /// ConcurrentQueue are thread safe! Consider this solution if different order
        /// does not matter.
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customerName"></param>
        private static void PlaceOrders(ConcurrentQueue<string> orders, string customerName) {
            for (int i = 0; i < 5; i++ ) {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", customerName, i + 1);
                orders.Enqueue(orderName);
            }
        }
    }
}