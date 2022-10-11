using System.Reflection;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public abstract class MainClass 
    {
        protected List<string> _execSteps;

        public MainClass()
        {

        }

        public IList<string> RealizeStepByStep()
        {
            _execSteps = new List<string>();
            Step1();
            Step2();
            Step3();
            Step4();

            if (Hook()){
                Step5();
            }

            return _execSteps;
        }

        private void Step1() { 
            _execSteps.Add(string.Concat(MethodBase.GetCurrentMethod().DeclaringType.Name,".",MethodBase.GetCurrentMethod().Name));
        }
        private void Step2() {

            _execSteps.Add(string.Concat(MethodBase.GetCurrentMethod().DeclaringType.Name,".",MethodBase.GetCurrentMethod().Name));
         }
        protected abstract void Step3();
        protected abstract void Step4();
        private void Step5() { 
            _execSteps.Add(string.Concat(MethodBase.GetCurrentMethod().DeclaringType.Name,".",MethodBase.GetCurrentMethod().Name));
        }

        protected abstract bool Hook();
    }
}