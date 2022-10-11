using System;
using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Composite
{
    public class Node : MyTreeNode {
        public Node(string name)
        {
            this.Name = name;
            this.Children = new List<MyTreeNode>();
            this.ItemsVisited = new List<string>();
        }
        private string Name { get; set; }
        private IList<MyTreeNode> Children { get; set; }

        public List<String> ItemsVisited { get; private set; }

        public override void AddChild(MyTreeNode e){
            this.Children.Add(e);
        }
        public override string GetName(){
            return this.Name;
        }
        public override MyTreeNode GetChild(int position){
            return this.Children[position];
        }
        public override IList<string> Print(){
            Console.WriteLine(this.Name);
            this.ItemsVisited.Add(this.Name);

            foreach(var item in Children){
                Console.Write("\t");
                this.ItemsVisited.AddRange(item.Print());
            }
            return this.ItemsVisited;
        }
    }
}
