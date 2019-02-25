using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConcurrentCollections {
    //class ConcurrentDictionary {    
    class Program {
        static void Main(string[] args) {
            //BadPracticeConcurrentDictionary();

            //ConcurrentDictionaryThrowsAnException();

            //ConcurrentDictionaryUsingTryAddAndTryRemove();

            //ConcurrentDictionaryUsingTryUpdate();

            //UsingAddOrUpdate();

            UsingGetOrAdd();
        }

        /// <summary>
        /// There are thre ways to looking up a value in dictionary:
        ///     1 - Indexer: 
        ///         int test = stock["key"]; (you must be sure that key exists!)
        ///     2 - Trygetvalue :
        ///         success = stock.TryGetValue("key", out test) (consider this case if you don't want to change anything in your dictionary)
        ///     3 - ConcurrentDictionary only - GetOrAdd: 
        ///         int test = stock.GetOrAdd("key", 0);
        ///         
        ///  In general, it's very important to consider for using concurrentdictionary you will 
        ///  have to be sure using atomic operation while performing operation with them, so 
        ///  in this way, you will be able to avoid race conditions and unexpected behaviors from your
        ///  app.
        /// </summary>
        private static void UsingGetOrAdd() {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            bool success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succedded? " + success);

            success = stock.TryAdd("pluralsight", 8);
            Console.WriteLine("Added succedded? " + success);

            stock["buddhistgeeks"] = 5;

            //stock["pluralsight"]++; // this is wrong code for a multithread
            int psStock = stock.AddOrUpdate("pluralsight", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine("New value is " + psStock);

            Console.WriteLine("stock[pluralsight] = {0}" + stock.GetOrAdd("pluralsight", 0));

            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if ( success )
                Console.WriteLine("Value removed was:  " + jDaysValue);

            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }

        private static void UsingAddOrUpdate() {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            bool success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succedded? " + success);

            success = stock.TryAdd("pluralsight", 8);
            Console.WriteLine("Added succedded? " + success);

            stock["buddhistgeeks"] = 5;

            //stock["pluralsight"]++; // this is wrong code for a multithread
            int psStock = stock.AddOrUpdate("pluralsight", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine("New value is " + psStock);

            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if ( success )
                Console.WriteLine("Value removed was:  " + jDaysValue);

            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }

        /// <summary>
        /// Try update operations are atomic and will not change values if the operation
        /// fails.
        /// </summary>
        private static void ConcurrentDictionaryUsingTryUpdate() {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            bool success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succedded? " + success);

            success = stock.TryAdd("pluralsight", 8);
            Console.WriteLine("Added succedded? " + success);

            stock["buddhistgeeks"] = 5;
            //stock["pluralsight"] = 7;
            success = stock.TryUpdate("pluralsight", 7, 6);
            Console.WriteLine("pluralsight = {0}, did update work? {1}", stock["pluralsight"], success);

            success = stock.TryUpdate("pluralsight", 8, 6);
            Console.WriteLine("pluralsight = {0}, did update work? {1}", stock["pluralsight"], success);

            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if ( success )
                Console.WriteLine("Value removed was:  " + jDaysValue);

            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }

        /// <summary>
        /// Using TryAdd and TryRemove
        /// </summary>
        private static void ConcurrentDictionaryUsingTryAddAndTryRemove() {
            var stock = new ConcurrentDictionary<string, int>();
            stock.TryAdd("jDays", 4);
            stock.TryAdd("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            bool success = stock.TryAdd("pluralsight", 6);
            Console.WriteLine("Added succedded? " + success);

            success = stock.TryAdd("pluralsight", 8);
            Console.WriteLine("Added succedded? " + success);

            stock["buddhistgeeks"] = 5;
            stock["pluralsight"] = 7;

            Console.WriteLine("\r\nstock[plurasight] = {0}", stock["pluralsight"]);

            int jDaysValue;
            success = stock.TryRemove("jDays", out jDaysValue);
            if ( success )
                Console.WriteLine("Value removed was:  " + jDaysValue);

            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }

        /// <summary>
        /// This method throws an exception because the sequencial add for "pluralsight"
        /// </summary>
        private static void ConcurrentDictionaryThrowsAnException() {
            IDictionary<string, int> stock = new ConcurrentDictionary<string, int>();
            stock.Add("jDays", 4);
            stock.Add("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            stock.Add("pluralsight", 6);
            stock.Add("pluralsight", 8);
            stock["buddhistgeeks"] = 5;
            stock["pluralsight"] = 7;

            Console.WriteLine("\r\nstock[plurasight] = {0}", stock["pluralsight"]);

            stock.Remove("jDays");
            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }

        /// <summary>
        /// THIS CODE DOES NOT FOLLOW GOOD PRACTICES!!!
        /// </summary>
        private static void BadPracticeConcurrentDictionary() {
            IDictionary<string, int> stock = new ConcurrentDictionary<string, int>();
            stock.Add("jDays", 4);
            stock.Add("technologyhour", 3);
            Console.WriteLine("No. of shirt in Stock = {0}", stock.Count);

            stock.Add("pluralsight", 6);
            stock["buddhistgeeks"] = 5;
            stock["pluralsight"] = 7;

            Console.WriteLine("\r\nstock[plurasight] = {0}", stock["pluralsight"]);

            stock.Remove("jDays");
            Console.WriteLine("\r\nEnumeratin:");
            foreach ( var keyValuePair in stock ) {
                Console.WriteLine("{0}: {1}", keyValuePair.Key, keyValuePair.Value);

            }
        }
    }
}
