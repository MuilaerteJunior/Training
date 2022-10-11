using System;

namespace DesignPatterns.Structural.Bridge
{
    internal class UniversalRemoteFromBrazil : AbstractRemoteControl
    {
        public override void Off()
        {
            throw new NotImplementedException();
        }

        public override string On()
        {
            return nameof(UniversalRemoteFromBrazil);
        }
    }
}
