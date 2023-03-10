using DesignPatterns.Behavioral.Mediator;
using Xunit;

namespace DesignPatterns.Tests.Behavioral
{
    public class MediatorTests
    {

        [Fact]
        public void Validate()
        {
            var testMediator = new SmartHomeMediator();
            var coffee = new CoffeeMachine(testMediator);
            var calendar = new Calendar(testMediator);
            var alarm = new Alarm(testMediator);

            testMediator.MyCoffeeMachine = coffee;
            testMediator.MyCalendar = calendar;
            testMediator.MyAlarm = alarm;

            var result = coffee.UpdateState("abc");
            Assert.Equal("Coffee!", result);

            result = alarm.UpdateState("abc");
            Assert.Equal("Snooze!", result);

            result = calendar.UpdateState("abc");
            Assert.Equal("MyCalendar!", result);
        }
    }
}