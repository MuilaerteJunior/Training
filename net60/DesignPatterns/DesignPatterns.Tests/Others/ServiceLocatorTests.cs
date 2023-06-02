using DesignPatterns.Structural.Adapter;
using Xunit;
using System.Reflection;
using System.Linq;
using DesignPatterns.Others.ServiceLocatorPattern;

namespace DesignPatterns.Tests.Others
{
    public class ServiceLocatorTests
    {
        private MyServiceLocator _serviceLocator;

        public ServiceLocatorTests()
        {
            _serviceLocator = MyServiceLocator.GetInstance();
        }

        [Fact]
        public void CheckServiceRegistrations()
        {
            _serviceLocator.Register<IServiceDoCoolStuffs>(new ServiceDoCoolStuffs());
            _serviceLocator.Register<IServiceDoNiceThings>(new ServiceDoNiceThings());

            Assert.Contains(_serviceLocator.Services, a => a.Key.Equals(typeof(ServiceDoCoolStuffs).FullName));
            Assert.Contains(_serviceLocator.Services, a => a.Key.Equals(typeof(ServiceDoNiceThings).FullName));
        }

        [Fact]
        public void CheckServiceUsages()
        {
            _serviceLocator.Register<IServiceDoCoolStuffs>(new ServiceDoCoolStuffs());
            _serviceLocator.Register<IServiceDoNiceThings>(new ServiceDoNiceThings());

            Assert.Equal("Cool stuffs!", _serviceLocator.Get<ServiceDoCoolStuffs>().BeCool());
            Assert.Equal("Nice things!", _serviceLocator.Get<ServiceDoNiceThings>().NiceThings());
        }
    }
}
