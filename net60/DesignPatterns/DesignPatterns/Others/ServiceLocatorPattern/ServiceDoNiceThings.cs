using System;

namespace DesignPatterns.Others.ServiceLocatorPattern
{
    internal class ServiceDoNiceThings : IServiceDoNiceThings
    {
        public string NiceThings()
        {
            return "Nice things!";
        }
    }
}
