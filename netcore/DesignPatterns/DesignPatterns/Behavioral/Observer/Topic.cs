using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
    public class Topic : ISubjectT<IObserverT<Topic>>, IObserver
    {
        private IList<IObserverT<Topic>> _subscriptions;
        public string CurrentContent { get;  private set; }

        public Topic()
        {
            _subscriptions = new List<IObserverT<Topic>>();
            CurrentContent = "My first state!";
        }

        public void Register(IObserverT<Topic> parameter)
        {
            if ( !_subscriptions.Contains(parameter)){
                _subscriptions.Add(parameter);                
                parameter.Update(this);
            }
        }

        public void Unregister(IObserverT<Topic> parameter)
        {
            if ( _subscriptions.Contains(parameter)){
                parameter.Update(null);
                _subscriptions.Remove(parameter);
            }
        }
        
        private void Notify()
        {
            foreach (var item in _subscriptions){                
                item.Update(this);
            }
        }

        public void DoSomething()
        {
            CurrentContent = "I changed my mind!";
            Notify();
        }

        public int SubscribersCount()
        {
            return _subscriptions.Count;
        }
    }
}