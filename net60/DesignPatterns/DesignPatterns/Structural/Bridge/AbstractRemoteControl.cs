using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DesignPatterns.Tests")]
namespace DesignPatterns.Structural.Bridge
{
    internal abstract class AbstractRemoteControl
    {
        protected ImplementorTV _myTV;
        public ImplementorTV MyTV
        {
            set { _myTV = value; }
        }

        public abstract string On();
        public abstract void Off();

        public string NextChannel()
        {
            return _myTV.TuneChannel();
        }
    }
}
