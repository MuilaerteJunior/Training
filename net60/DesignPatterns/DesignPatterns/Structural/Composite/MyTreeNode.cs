using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Composite
{
    //Composite
    public abstract class MyTreeNode {
        
        public virtual void AddChild(MyTreeNode e){
            throw new NotImplementedException();
        }

        public virtual string GetName(){
            throw new NotImplementedException();
        }
        public virtual MyTreeNode GetChild(int position){
            throw new NotImplementedException();
        }
        public virtual IList<string> Print()
        {
            throw new NotImplementedException();
        }
    }
}
