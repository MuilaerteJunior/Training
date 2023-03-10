namespace DesignPatterns.Behavioral.Mediator
{
    public class Alarm : SmartThing
    {
        ISmartHomeMediator _myMediator;
        public Alarm(ISmartHomeMediator mediator)
        {
            _myMediator = mediator;
        }

        public override string UpdateState(string change)
        {
            return _myMediator.Update(change, this);
        }

        public string Snooze()
        {
            return "Snooze!";
        }
    }

}
