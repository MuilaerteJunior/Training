using DesignPatterns.Creational;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using DesignPatterns.Models;
using System.Threading;
using System;
using System.Reflection;
using System.Collections.Generic;
using DesignPatterns.Behavioral;
using Moq;

namespace DesignPatterns.Tests.Creational
{
    public class StrategyTests
    {
        [Fact( DisplayName = "Validating if main class are able to apply as 'Strategist'")]
        public void ValidateStrategyDefinition(){
            var a = typeof(Strategy);
            var i = typeof(IStrategy);
            
            Assert.Contains(a.GetFields(BindingFlags.Instance | BindingFlags.NonPublic), f=> f.FieldType == i);
            Assert.Contains(a.GetMethods(BindingFlags.Instance | BindingFlags.Public), m => m.GetParameters().Any(p => p.ParameterType == i));
        }


        [Fact( DisplayName = "Validating if main class are able to apply as 'Strategist' 2")]
        public void ValidateStrategyDefinition3()
        {
            var concreteStrategy = new Mock<Strategy>();
            var cs1 = new Strategy();
            var firstStrategy = new Mock<IStrategy>();
            var secondStrategy = new  Mock<IStrategy>();

            firstStrategy.Setup(s1 => s1.Execute());

            cs1.Use(firstStrategy.Object);
            cs1.Execute();
            firstStrategy.Verify(s => s.Execute(), Times.Once);
            
            secondStrategy.Setup(s2 => s2.Execute());
            cs1.Use(secondStrategy.Object);
            cs1.Execute();
            secondStrategy.Verify(s => s.Execute(), Times.Once);
        }
    }
}