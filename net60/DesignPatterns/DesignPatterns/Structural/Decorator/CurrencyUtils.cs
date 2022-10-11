using System.Linq;

namespace DesignPatterns.Structural.Decorator
{
    public static class CurrencyUtils  {
        public static Currency SumCurrencies(params Currency[] currencies){
            return new Currency(currencies.Sum(c => c.Value));
        }
    }
}