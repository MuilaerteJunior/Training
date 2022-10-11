using DesignPatterns.Structural.Bridge;
using Xunit;

namespace DesignPatterns.Tests.Structural
{
    public class BridgeTests
    {
        [Fact(DisplayName ="Validates the Bridge design pattern - Implementation Part")]
        public void Validate_Bridge_Implementation_Part()
        {
            AbstractRemoteControl abstraction = new UniversalRemoteFromBrazil();
            abstraction.MyTV = new SamsungTV();
            var r1 = abstraction.NextChannel();

            abstraction.MyTV = new SonyTV();
            var r2 = abstraction.NextChannel();

            Assert.Equal("Samsung TV", r1);
            Assert.Equal("Sony TV", r2);
        }

        [Fact(DisplayName = "Validates the Bridge design pattern - Abstraction part")]
        public void Validate_Bridge_Abstraction_Part()
        {
            AbstractRemoteControl abstraction = new UniversalRemoteFromBrazil();
            var r1 = abstraction.On();

            abstraction = new UniversalRemoteFromChina();
            var r2 = abstraction.On();

            Assert.Equal(nameof(UniversalRemoteFromBrazil), r1);
            Assert.Equal(nameof(UniversalRemoteFromChina), r2);
        }
    }
}

