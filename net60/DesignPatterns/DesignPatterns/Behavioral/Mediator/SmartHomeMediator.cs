using DesignPatterns.Behavioral.Mediator;

namespace DesignPatterns.Tests.Behavioral
{
    public class SmartHomeMediator : ISmartHomeMediator
    {
        private CoffeeMachine _myCoffeeMachine;
        public CoffeeMachine MyCoffeeMachine { set { _myCoffeeMachine = value;  } }

        private Calendar _myCalendar;
        public Calendar MyCalendar { set { _myCalendar = value; } }

        private Alarm _myAlarm;
        public Alarm MyAlarm { set { _myAlarm = value; } }

        public SmartHomeMediator() { }

        public string Update(string change, SmartThing caller)
        {
            if ( caller == _myCoffeeMachine)
            {
                return _myCoffeeMachine.PrepareCoffee();
            } else if ( caller == _myCalendar)
            {
                return _myCalendar.ShowMyEvents();
            } else if ( caller == _myAlarm)
            {
                var a = _myCoffeeMachine.PrepareCoffee();
                return _myAlarm.Snooze();
            }

            return null;
        }
    }
}