namespace DesignPatterns.Structural.Facade
{
    public class SimplifierFacade : ISimplifierFacade
    {
        private IIsolatedContext1 _isolatedContext1;
        private IIsolatedContext2 _isolatedContext2;

        public SimplifierFacade(IIsolatedContext1 isolatedContext1
                                , IIsolatedContext2 isolatedContext2)
        {
            _isolatedContext1 = isolatedContext1;
            _isolatedContext2 = isolatedContext2;
        }
        public void Play()
        {
            _isolatedContext1.LightUpTheEnvironment();
            _isolatedContext2.PickupASong();
        }
    }
}