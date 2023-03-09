using Xunit;
using DesignPatterns.Behavioral.ChainOfResponsability;

namespace DesignPatterns.Tests.Creational
{
    public class ChainOfResponsabilityTests
    {
        [Fact]
        public void Validate_StringProcess()
        {
            var testCase  = new StringHandler();
            testCase.HandleRequest("test");
            Assert.Equal(2, testCase.Stages.Count);
            Assert.Equal("ObjectHandler", testCase.Stages.Pop());
            Assert.Equal("StringHandler", testCase.Stages.Pop());
        }


        [Fact]
        public void Validate_ObjectProcess()
        {
            var testCase = new StringHandler();
            testCase.HandleRequest(1);
            Assert.Single(testCase.Stages);
            Assert.Equal("ObjectHandler", testCase.Stages.Pop());
        }
    }
}