namespace DesignPatterns.Behavioral.Mediator
{
    public class Calendar : SmartThing
    {
        ISmartHomeMediator _myMediator;
        public Calendar(ISmartHomeMediator mediator)
        {
            _myMediator = mediator;
        }
        public override string UpdateState(string change)
        {
            return _myMediator.Update(change, this);
        }

        public string ShowMyEvents()
        {
            return "MyCalendar!";
        }
    }

}
