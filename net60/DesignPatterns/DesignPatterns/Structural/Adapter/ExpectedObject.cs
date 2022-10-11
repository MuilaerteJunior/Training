namespace DesignPatterns.Structural.Adapter
{
    public class ExpectedObject : IExpectedInterface {
        private readonly ImmutableInterface _expectedObject;

        public ExpectedObject(ImmutableInterface expectedObject)
        {
            _expectedObject = expectedObject;
        }

        public string DoAnotherSomething()
        {
            return _expectedObject.DoSomething();
        }
    }
}