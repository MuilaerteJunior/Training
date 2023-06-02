using System;

namespace DesignPatterns.Others.ServiceLocatorPattern
{
    internal class ServiceDoCoolStuffs : IServiceDoCoolStuffs
    {
        public string BeCool()
        {
            return "Cool stuffs!";
        }
    }
}
