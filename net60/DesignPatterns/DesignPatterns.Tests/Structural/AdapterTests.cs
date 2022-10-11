using DesignPatterns.Structural.Adapter;
using Xunit;
using System.Reflection;
using System.Linq;

namespace DesignPatterns.Tests.Structural
{
    //1 -> A test to validate that a are a divergence between expected class and first object
    //2 -> A test to validate that after the adapter, the result expected is the same 
    public class AdapterTests {
        [Fact(DisplayName = "Validating divergence between expected class and current object in hands")]
        public void CheckIfTheExpectedContextHaveSupportForTheImmutableObject(){
            var parametersAcceptable = typeof(ExpectedContext)
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .SelectMany(mi => mi.GetParameters(), (mi, p) => p.ParameterType);
            Assert.DoesNotContain(typeof(ImmutableObject), parametersAcceptable);
        }

        [Fact(DisplayName = "Validating if after applying Adapter Concepts, the result expected from the original class it will remains")]
        public void CheckTheAdapterFunctionality(){
            var i = new ImmutableObject();
            var exGuy = new ExpectedObject(i);
            var exContext = new ExpectedContext();
            exContext.Use(exGuy);
            Assert.Equal(i.DoSomething(), exGuy.DoAnotherSomething());
        }
    }
}

