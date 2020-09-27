using Lamar;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.DependencyInjection
{
    public class EntityTestsServiceRegistryCollection : ServiceRegistry
    {
        public EntityTestsServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<EntityTestsServiceRegistryCollection>();
                    scanner.AddAllTypesOf(typeof(IEntityBuilder<>));
                    scanner.WithDefaultConventions();
                });

        }
    }
}