using System;

namespace DesignPatterns.Structural.Decorator
{
    ///Decorator
    public abstract class DrinkDecorator<T> : IDrink  where T : IDrink
    {
        private T _drink;

        public DrinkDecorator(T a)
        {
            if ( a == null) throw new ArgumentNullException();
                
            _drink = a;
        }

        public T GetMyOrigin() {
            return _drink;
        }

        public Currency Cost()
        {
            return _drink.Cost();
        }

        public string GetDescription()
        {
            return _drink.GetDescription();
        }
    }
}