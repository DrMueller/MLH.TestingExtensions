using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Factories;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Infrastructure.DependencyInjection
{
    public class TestingExtensionsRegistry : Registry
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