using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections {
    class Program {
        static void Main(string[] args) {
            var stock = new Dictionary<string, int>() {
                { "jDays" , 4 },
                { "technologyhour" , 3 }
            };

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
