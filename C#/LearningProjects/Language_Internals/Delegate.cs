using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Language_Internals
{
    class Program {
        static void Main() {
            Func<int, int> f = delegate (int x) {
                return x * 2;
            };

            Func<int,int> otherDelegate = (g) => g * 2;
        }

    }

}