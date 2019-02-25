using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections.SalesBonuses
{
    public class StaffLogsForBonuses {
        private ConcurrentDictionary<SalesPerson, int> _salesByPerson = new ConcurrentDictionary<SalesPerson, int>();
        private ConcurrentDictionary<SalesPerson, int> _purchasesByPerson = new ConcurrentDictionary<SalesPerson, int>();

        public void ProcessTrade(Trade sale) {
            //Thread.Sleep(300);
            if ( sale.QuantitySold > 0 )
                _salesByPerson.AddOrUpdate(sale.Person,
                    sale.QuantitySold,
                    (key, oldValue) => oldValue + sale.QuantitySold);
            else
                _purchasesByPerson.AddOrUpdate(sale.Person,
                    sale.QuantitySold,
                    (key, oldValue) => oldValue - sale.QuantitySold);
        }

        public void DisplayReport(SalesPerson[] people) {
            Console.WriteLine();
            Console.WriteLine("Transactions by salesperson: ");
            foreach ( var person in people ) {
                int sales = _salesByPerson.GetOrAdd(person, 0);
                int purchases = _purchasesByPerson.GetOrAdd(person, 0);
                Console.WriteLine("{0,15} sold {1,3}, bought {2,3} items, total {3}",
                    person.Name,
                    sales, 
                    purchases,
                    sales + purchases);
            }
        }
    }

}