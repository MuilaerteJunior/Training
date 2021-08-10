using DesignPatterns.Behavioral.TemplateMethod;
using Xunit;

namespace DesignPatterns.Tests.Behavioral
{
    public class TemplateMethodTests{
        [Fact(DisplayName = "Validate template method application")]
        public void ValidateTemplateMethod(){
            var mainclass1 = new SpecificClass1UseHook();
            var r = mainclass1.RealizeStepByStep();
            Assert.Contains(r, a => a.Contains("SpecificClass1UseHook"));

            var mainclass2 = new SpecificClass2NoHook();
            r = mainclass2.RealizeStepByStep();
            Assert.Contains(r, a => a.Contains("SpecificClass2NoHook"));
        }

        [Fact(DisplayName = "Validate hook usage for a template method.")]
        public void ValidateTemplateMethod_HookExecution(){
            var mainclass1 = new SpecificClass1UseHook();
            var r = mainclass1.RealizeStepByStep();
            Assert.Contains(r, a => a.Contains("Step5"));

            var mainclass2 = new SpecificClass2NoHook();
            r = mainclass2.RealizeStepByStep();            
            Assert.DoesNotContain(r, a => a.Contains("Step5"));
        }
    }
}

