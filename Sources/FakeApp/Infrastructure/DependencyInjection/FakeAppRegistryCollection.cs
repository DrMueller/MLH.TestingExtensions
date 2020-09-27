using Lamar;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Factories;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Factories.Implementation;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Infrastructure.DependencyInjection
{
    public class FakeAppRegistryCollection : ServiceRegistry
    {
        public FakeAppRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<FakeAppRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IAppDbContextFactory>().Use<AppDbContextFactory>().Singleton();
        }
    }
}