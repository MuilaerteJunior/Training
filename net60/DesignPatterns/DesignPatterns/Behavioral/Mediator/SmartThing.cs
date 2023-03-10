using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Mediator
{
    public abstract class SmartThing
    {
        public abstract string UpdateState(string change);
    }

}
