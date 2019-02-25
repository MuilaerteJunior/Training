using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ConcurrentCollections.SalesBonuses {

    public class StockController {
        ConcurrentDictionary<string, int> _stock = new ConcurrentDictionary<string, int>();
        int _totalQuantityBought;
        int _totalQuantitySold;
        ToDoQueueBlockingCollection _toDoQueue;

        //public StockController(ToDoQueue bonusCalculator) {
        public StockController(ToDoQueueBlockingCollection bonusCalculator) {
            this._toDoQueue = bonusCalculator;
        }

        public void BuyStock(SalesPerson person, string item, int quantity) {
            _stock.AddOrUpdate(item, quantity, (key, oldvalue) => oldvalue + quantity);
            Interlocked.Add(ref _totalQuantityBought, quantity);
            _toDoQueue.AddTrade(new Trade(person, quantity));
        }

        public bool TrySellItem(SalesPerson person, string item) {
            bool success = false;
            int newStockLevel = _stock.AddOrUpdate(item,
                (itemName) => { success = false;  return 0; },
                (itemName, oldValue) => {
                    if (oldValue == 0 ) {
                        success = false;
                        return 0;
                    } else {
                        success = true;
                        return oldValue - 1;
                    }
                });

            if ( success ) {
                Interlocked.Increment(ref _totalQuantitySold);
                _toDoQueue.AddTrade(new Trade(person, 1));
            }
            return success;
        }

        public void DisplayStatus() {
            int totalStock = _stock.Values.Count;

            Console.WriteLine("\r\nBought =  {0}", _totalQuantityBought);
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
