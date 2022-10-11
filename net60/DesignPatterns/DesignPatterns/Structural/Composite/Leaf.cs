using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Composite
{
    public class Leaf : MyTreeNode {
        private string Name { get; set; }

        public Leaf(string name)
        {
            this.Name = name;
        }

        public override string GetName(){
            return this.Name;
        }
        public override IList<string> Print(){
            Console.WriteLine(string.Concat("\t",this.Name));
            return new List<string> { this.Name };
        }
    }
}
