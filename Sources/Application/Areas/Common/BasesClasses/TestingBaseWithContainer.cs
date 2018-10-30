using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using NUnit.Framework;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses
{
    [TestFixture]
    public abstract class TestingBaseWithContainer
    {
        private IContainer _container;
        protected static IServiceLocator ServiceLocator => ServiceLocatorSingleton.Instance;

        [SetUp]
        public void AlignBase()
        {
            _container = ContainerInitializationService.CreateInitializedContainer(ContainerConfiguration.CreateFromAssembly(GetType().Assembly));
            OnAlign();
        }

        protected virtual void OnAlign()
        {
        }

        protected void RegisterInstance<TPluginType>(TPluginType instance)
            where TPluginType : class
        {
            _container.Configure(config => config.For<TPluginType>().Use(instance));
        }
    }
}