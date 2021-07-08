namespace DesignPatterns.Structural.Decorator
{
    public class Currency {
        public Currency(decimal v)
        {
            CurrencyName = "Dollars";
            this.Value = v;
        }

        public string CurrencyName { get; set; }
        public decimal Value { get; set; }
    }
}