using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator
{
    public class Whisky : IDrink
    {
        public Currency Cost()
        {
            return new Currency(5m);
        }

        public string GetDescription()
        {
            return "Whisky";
        }
    }
}