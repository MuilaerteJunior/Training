using DesignPatterns.Structural.Facade;
using Moq;
using Xunit;

namespace DesignPatterns.Tests.Structural
{
    public class FacadeTests {
        ///It creates two mocked object as two different isolated contexts, create the facade object, and check if by calling the main method from Facade,
        //it will be calling the methods from isolated contexts.
        [Fact(DisplayName= "Validate the Facade Design pattern.")]
        public void Validate_Facade(){
            var isolatedContext1 = new Mock<IIsolatedContext1>();
            var otherIsolatedContext = new Mock<IIsolatedContext2>();

            //Mocking the interfaces
            isolatedContext1.Setup(c => c.LightUpTheEnvironment());
            otherIsolatedContext.Setup(c => c.PickupASong());

            //Creating the facade object, or the "simplifier" object
            var facade = new SimplifierFacade(isolatedContext1.Object, otherIsolatedContext.Object);
            facade.Play();

            //Checking if the isolated objects were called, as the facade proposed to be a simplifier
            isolatedContext1.Verify(c => c.LightUpTheEnvironment(), Times.AtLeastOnce);            
            otherIsolatedContext.Verify(c => c.PickupASong(), Times.AtLeastOnce);
        }
    }
}

