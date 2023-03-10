namespace DesignPatterns.Behavioral.Mediator
{
    public class CoffeeMachine : SmartThing
    {
        ISmartHomeMediator _myMediator;
        public CoffeeMachine(ISmartHomeMediator mediator)
        {
            _myMediator = mediator;
        }
        public override string UpdateState(string change)
        {
            return _myMediator.Update(change, this);
        }

        public string PrepareCoffee()
        {
            return "Coffee!";
        }
    }

}
