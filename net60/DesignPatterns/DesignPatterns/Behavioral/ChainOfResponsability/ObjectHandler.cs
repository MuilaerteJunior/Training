namespace DesignPatterns.Behavioral.ChainOfResponsability
{
    public class ObjectHandler : CoreHandler
    {
        public override string HandleRequest<T>(T t)
        {
            if (t != null)
                return HandleIt();

            return null;
        }

        private string HandleIt()
        {
            return "ObjectHandler";
        }
    }
}
