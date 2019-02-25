using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace ConcurrentCollections.ConcurrentDemo {
    public class StockController {
        ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
        int _totalQuantityBought;
        int _totalQuantitySold;

        public void BuyStock(string itemKey, int quantity) {
            _stock.AddOrUpdate(itemKey, quantity, (key, oldValue) => oldValue + quantity);
            Interlocked.Add(ref _totalQuantityBought, quantity);//Doing in this way it will avoid race conditions!
        }

        public bool TrySellitem(string itemKey) {
            bool success = false;
            
            //Make sure delegates supplied can execute more than once!!!
            int _newstockLevel = _stock.AddOrUpdate(itemKey,
                (itemName) => { success = false; return 0; },
                (itemName, oldValue) => {
                    if ( oldValue == 0 ) {
                        success = false;
                        return 0;
                    } else {
                        success = true;
                        return oldValue - 1;
                    }
                });

            if ( success )
                Interlocked.Increment(ref _totalQuantitySold);

            return success;
        }

        /// <summary>
        /// This method call AddOrUpdate twice but it's a reduced code. It's breaked into simpler
        /// operations. Observation 1: stock levels go negative and performance may be worse.
        /// </summary>
        /// <param name="itemKey"></param>
        /// <returns></returns>
        public bool TrySellitem2(string itemKey) {
            int newstockLevel = _stock.AddOrUpdate(itemKey, -1, (itemName, oldValue) => oldValue - 1);
            if ( newstockLevel < 0 ) {
                _stock.AddOrUpdate(itemKey, 1, (itemName, oldValue) => oldValue + 1);
                return false;
            }
            else {
                Interlocked.Increment(ref _totalQuantitySold);
                return true;
            }
        }

        public void DisplayStatus() {
            int totalStock = _stock.Values.Sum();

            Console.WriteLine("\r\nBrought =  {0}", _totalQuantityBought);
            Console.WriteLine("Total Sold: {0}", _totalQuantitySold);
            Console.WriteLine("Total stock: {0}", totalStock);


            int error = totalStock + _totalQuantitySold - _totalQuantityBought;
            if ( error == 0 )
                Console.WriteLine("Stock levels match");
            else 
                Console.WriteLine("Error in stock level: " + error);


            Console.WriteLine("\nStock levels by item:");
            foreach ( var itemInStock in Program.AllShirtNames ) {
                int stocklevel = _stock.GetOrAdd(itemInStock, 0);
                Console.WriteLine("{0,-30}: {1}", itemInStock, stocklevel);
            }
        }
    }
}
