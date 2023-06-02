using System.Collections.Generic;

namespace DesignPatterns.Others.ServiceLocatorPattern
{

    /// <summary>
    /// References: https://www.codeproject.com/Articles/5337102/Service-Locator-Pattern-in-Csharp
    /// </summary>
    internal class MyServiceLocator
    {
        private static readonly MyServiceLocator _unique = new();

        private readonly Dictionary<string, object> _services = new();
        public Dictionary<string, object> Services { get { return _services; } }

        private MyServiceLocator() { }
        public static MyServiceLocator GetInstance()
        {
            return _unique;
        }

        internal void Register<T>(T service) 
        {
            if (!_services.ContainsKey(service.GetType().FullName)){
                _services.Add(service.GetType().FullName, service);
            } else
            {
                _services[service.GetType().FullName] = service;
            }
        }

        internal T Get<T>() 
        {
            if (_services.ContainsKey(typeof(T).FullName))
                return (T) _services[typeof(T).FullName];

            throw new KeyNotFoundException();
        }
    }
}
