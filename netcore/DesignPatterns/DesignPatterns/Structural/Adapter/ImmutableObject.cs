namespace DesignPatterns.Structural.Adapter
{
    public class ImmutableObject : ImmutableInterface
    {
        public string DoSomething()
        {
            return "OK, I can do something!";
        }
    }
}