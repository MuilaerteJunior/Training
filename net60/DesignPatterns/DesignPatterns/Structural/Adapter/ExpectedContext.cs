namespace DesignPatterns.Structural.Adapter
{
    public sealed class ExpectedContext {
        public void Use(ExpectedObject obj){
            obj.DoAnotherSomething();
        }
    }
}