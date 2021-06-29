namespace DesignPatterns.Behavioral.Observer
{
    public interface IObserverT<T> : IObserver  
                 where  T : IObserver
    { 
        internal void Update(T tclass);
    }
}