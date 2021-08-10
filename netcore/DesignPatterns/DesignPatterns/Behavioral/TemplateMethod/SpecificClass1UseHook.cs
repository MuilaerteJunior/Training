using System.Reflection;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public class SpecificClass1UseHook : MainClass
    {
        protected override bool Hook()
        {
            return true;
        }

        protected override void Step3()
        {
            _execSteps.Add(string.Concat(MethodBase.GetCurrentMethod().DeclaringType.Name,".",MethodBase.GetCurrentMethod().Name));
            
        }

        protected override void Step4()
        {
            _execSteps.Add(string.Concat(MethodBase.GetCurrentMethod().DeclaringType.Name,".",MethodBase.GetCurrentMethod().Name));
        }
    }
}