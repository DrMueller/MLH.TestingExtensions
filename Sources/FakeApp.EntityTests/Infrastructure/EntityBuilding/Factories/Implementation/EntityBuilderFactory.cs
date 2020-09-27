using JetBrains.Annotations;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories.Implementation
{
    [UsedImplicitly]
    public class EntityBuilderFactory : IEntityBuilderFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public EntityBuilderFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public T Create<T>() where T : IEntityBuilder
        {
            return _serviceLocator.GetService<T>();
        }
    }
}