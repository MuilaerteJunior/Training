namespace DesignPatterns.Structural.Decorator
{
    public class NonAlcoholicDrink : IDrink
    {
        public Currency Cost()
        {
            return new Currency(2m);
        }

        public string GetDescription()
        {
            return "Juice";
        }
    }
}