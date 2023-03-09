namespace DesignPatterns.Behavioral.ChainOfResponsability
{
    public class StringHandler : CoreHandler
    {
        public StringHandler()
        {
            _sucessor = new ObjectHandler();
        }

        public override string HandleRequest<T>(T t)
        {
            if (t != null&& t is string)
                Stages.Push(HandleIt());

            if (_sucessor != null)
            {
                Stages.Push(_sucessor.HandleRequest(t));
                return Stages.Peek();
            }

            return null;
        }

        private string HandleIt()
        {
            return "StringHandler";
        }
    }

}
