using System;

namespace ConcurrentCollections.SalesBonuses {
    public class SalesPerson {
        public string Name { get; private set; }

        public SalesPerson(string _name) {
            this.Name = _name;
        }

        public void Work(StockController controller, TimeSpan workDay) {
            Random rand = new Random(this.Name.GetHashCode());
            DateTime start = DateTime.Now;

            while (DateTime.Now - start < workDay ) {
                //Thread.Sleep(rand.Next(100));
                bool buy = (rand.Next(6) == 0);//We sell 5 time to 1 buy
                string itemName = Program.AllShirtNames[rand.Next(Program.AllShirtNames.Count)];
                if ( buy ) {
                    int quantity = rand.Next(9) + 1;
                    controller.BuyStock(this, itemName, quantity);
                    //DisplayPurchase(itemName, quantity);
                } else {
                    bool success = controller.TrySellItem(this, itemName);
                    //DisplaySaleAttempt(success, itemName);
                }
            }

            Console.WriteLine("SalesPerson {0} signing of", this.Name);
        }
    }
}