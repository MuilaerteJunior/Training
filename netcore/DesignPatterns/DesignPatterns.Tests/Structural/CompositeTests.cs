using Xunit;
using DesignPatterns.Tests.Structural.Composite;
using System;

namespace DesignPatterns.Tests.Structural
{
    public class CompositeTests
    {
        /****
        GOSH
            ADAM
                MALE1
            EVA
                FEMALE1 
                FEMALE2
        */
        [Fact(DisplayName = "Validating Composite concepts")]
        public void ValidateComposite_Concepts(){
            //Arrange
            var gosh = new Node("Gosh");
            var adam = new Node("Adam");
            var eva = new Node("Eva");
            var male1 = new Leaf("Male 1");
            var female1 = new Leaf("Female 1");
            var female2 = new Leaf("Female 2");
            adam.AddChild(male1);
            eva.AddChild(female1);
            eva.AddChild(female2);
            gosh.AddChild(adam);
            gosh.AddChild(eva);
            
            var t = new CompleteTree(gosh);
            
            //Act
            var result = t.Print();

            //Assert            
            Assert.Contains("Gosh", result);
            Assert.Contains("Adam", result);
            Assert.Contains("Eva", result);
            Assert.Contains("Male 1", result);
            Assert.Contains("Female 1", result);
            Assert.Contains("Female 2", result);
        }
    }
}