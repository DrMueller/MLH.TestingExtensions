using Lamar;

namespace Mmu.Mlh.TestingExtensions.Infrastructure.DependencyInjection
{
    public class TestingExtensionsRegistry : ServiceRegistry
    {
        public TestingExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestingExtensionsRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}