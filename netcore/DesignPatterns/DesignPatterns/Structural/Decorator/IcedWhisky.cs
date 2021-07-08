namespace DesignPatterns.Structural.Decorator
{
    public class IcedWhisky : DrinkDecorator<Whisky>
    {
        public IcedWhisky(Whisky whisky) : base(whisky) { }

        public new Currency Cost()
        {
            return CurrencyUtils.SumCurrencies(new Currency(0.25m), base.Cost());
        }

        public new string GetDescription()
        {
            return string.Concat(base.GetDescription(),  ", 2 Ice cubes");
        }
    }
}