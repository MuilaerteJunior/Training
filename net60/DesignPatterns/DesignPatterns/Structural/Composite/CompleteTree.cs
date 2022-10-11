using System.Collections.Generic;

namespace DesignPatterns.Tests.Structural.Composite
{
    public class CompleteTree : MyTreeNode
    {
        private Node _rootNode;

        public CompleteTree(Node rootNode)
        {
            _rootNode = rootNode;
        }

        public override IList<string> Print(){    
            return _rootNode.Print();
        }
    }
}
