using DesignPatterns.Structural.Decorator;
using Xunit;
using System.Linq;
using System.Reflection;

namespace DesignPatterns.Tests.Structural
{
    public class DecoratorTests
    {
        [Fact(DisplayName = "Checking decorator main concepts")]
        public void ValidateDecorator_Concepts(){
            var whisky = new Whisky();
            var icedWhisky  = new IcedWhisky(whisky);
            Assert.Equal("Whisky",whisky.GetDescription());
            Assert.Equal("Whisky, 2 Ice cubes",icedWhisky.GetDescription());
            Assert.Equal(new Currency(5m).Value, whisky.Cost().Value);
            Assert.Equal(new Currency(5.25m).Value, icedWhisky.Cost().Value);
        }
        
        [Fact(DisplayName = "Checking decorator main concepts - 2")]
        public void ValidateDecorator_Concepts_2(){
            Assert.Contains(typeof(Whisky)
                            ,typeof(IcedWhisky).GetConstructors()
                                    .SelectMany(c => c.GetParameters(),(c , p) => p.ParameterType));
        }
    }
}

