using System.Reflection;

namespace DesignPatterns.Behavioral.Strategy
{

    public class Strategy
    {
        private IStrategy _t;

        public void Use(IStrategy s2)
        {
            _t = s2;
        }

        public void Execute()
        {
            _t.Execute();
        }
    }
}