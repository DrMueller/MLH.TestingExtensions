using Lamar;

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
        }
    }
}