using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections.SalesBonuses
{

    public class Trade {
        public SalesPerson Person { get; private set; }
        public int QuantitySold { get; private set; }

        public Trade(SalesPerson person, int quantity) {
            this.Person = person;
            this.QuantitySold = quantity;
        }
    }

}