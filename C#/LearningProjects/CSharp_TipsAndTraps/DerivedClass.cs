using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TipsAndTraps
{
    public class DerivedClass : BaseClass {
        protected override void InitName() {
            Name = null;
        }
    }
}