using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models.Implementation
{
    internal class IntegrationTestContext : IIntegrationTestContext
    {
        private readonly IContainer _container;
        public IServiceLocator ServiceLocator { get; }

        public IntegrationTestContext(IContainer container)
        {
            _container = container;
            ServiceLocator = container.GetInstance<IServiceLocator>();
        }

        public void RegisterInstance<TPluginType>(TPluginType instance)
            where TPluginType : class
        {
            _container.Configure(config => config.For<TPluginType>().Use(instance));
        }
    }
}