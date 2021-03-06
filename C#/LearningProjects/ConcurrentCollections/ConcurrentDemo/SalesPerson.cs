using System;
using System.Threading;

namespace ConcurrentCollections.ConcurrentDemo {
    public class SalesPerson {
        private string _name;

        public SalesPerson(string id) {
            this._name = id;
        }

        public void Work(StockController controller, TimeSpan workDay) {
            Random rand = new Random(_name.GetHashCode());
            DateTime start = DateTime.Now;

            while (DateTime.Now - start < workDay ) {
                //Thread.Sleep(rand.Next(100));
                bool buy = (rand.Next(6) == 0);//We sell 5 time to 1 buy
                string itemName = Program.AllShirtNames[rand.Next(Program.AllShirtNames.Count)];
                if ( buy ) {
                    int quantity = rand.Next(9) + 1;
                    controller.BuyStock(itemName, quantity);
                    //DisplayPurchase(itemName, quantity);
                } else {
                    bool success = controller.TrySellitem(itemName);
                    //DisplaySaleAttempt(success, itemName);
                }
            }

            Console.WriteLine("SalesPerson {0} signing of", this._name);
        }

        private void DisplayPurchase(string itemName, int quantity) {
            Console.WriteLine("Thread {0}: {1} bought {2} of {3}", 
                                Thread.CurrentThread.ManagedThreadId,
                                this._name,
                                quantity,
                                itemName);
        }

        private void DisplaySaleAttempt(bool success, string itemName) {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            if (success) 
                Console.WriteLine("Thread {0}: {1} sold {2}", threadId,  this._name, itemName);
            else
                Console.WriteLine("Thread {0}: {1} Out of stock of {2}", threadId,  this._name, itemName);

        }
    }
}