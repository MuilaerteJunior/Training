using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsability
{
    public interface IHandler
    {
        string HandleRequest<T>(T requestParameter);
    }

}
