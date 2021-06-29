namespace DesignPatterns.Behavioral.Observer
{
    public interface ISubjectT<TObserver>  where TObserver : IObserver
    {
        void Register(TObserver parameter);
        void Unregister(TObserver parameter);
        void DoSomething();
    }
}