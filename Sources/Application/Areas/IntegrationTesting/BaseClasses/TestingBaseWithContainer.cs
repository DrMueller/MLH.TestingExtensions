////using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
////using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
////using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
////using NUnit.Framework;
////using StructureMap;

////namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.BaseClasses
////{
////    [TestFixture]
////    public abstract class TestingBaseWithContainer
////    {
////        private IContainer _container;
////        protected static IServiceLocator ServiceLocator => ServiceLocatorSingleton.Instance;

////        [SetUp]
////        public void AlignBase()
////        {
////            var config = CreateContainerConfiguration();

////            _container = ContainerInitializationService.CreateInitializedContainer(
////                ContainerConfiguration.CreateFromAssembly(
////                    GetType().Assembly,
////                    config.NamespaceParts,
////                    config.InitializeAutoMapper,
////                    config.LogInitialization));

////            OnAligned();
////        }

////        protected virtual TestingContainerConfiguration CreateContainerConfiguration()
////        {
////            return TestingContainerConfiguration.CreateDefult();
////        }

////        protected virtual void OnAligned()
////        {
////        }

////        protected void RegisterInstance<TPluginType>(TPluginType instance)
////            where TPluginType : class
////        {
////            _container.Configure(config => config.For<TPluginType>().Use(instance));
////        }
////    }
////}