using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses.Servants;
using NUnit.Framework;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses
{
    [TestFixture]
    public abstract class TestingBaseWithContainer
    {
        private IContainer _container;
        protected IProvisioningService ProvisioningService => ProvisioningServiceSingleton.Instance;

        [SetUp]
        public void SetUpBase()
        {
            _container = ProvisioningServiceFactory.Create();
            OnSetUp();
        }

        protected virtual void OnSetUp()
        {
        }

        protected void RegisterInstance<TPluginType>(TPluginType instance)
            where TPluginType : class
        {
            _container.Configure(config => config.For<TPluginType>().Use(instance));
        }
    }
}