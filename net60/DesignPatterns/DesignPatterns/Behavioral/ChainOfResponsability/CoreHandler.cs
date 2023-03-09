using System.Collections.Generic;

namespace DesignPatterns.Behavioral.ChainOfResponsability
{
    public abstract class CoreHandler : IHandler
    {
        protected CoreHandler _sucessor;

        public Stack<string> Stages { get; protected set; } = new Stack<string>();

        public abstract string HandleRequest<T>(T requestParameter);
    }

}
