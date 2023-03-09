using DesignPatterns.Structural.FlyWeight;
using Xunit;

namespace DesignPatterns.Tests.Structural 
{ 
    public class FlyWeightTests
    {
        [Fact]
        public void Validate_Concept()
        {
            var m = new MyLittleObject();
            var flyweight = new MyLittleObjectManager();
            flyweight.AddMyObject(m);
            Assert.NotNull(flyweight.GetMyObject(0));
        }
    }
}

