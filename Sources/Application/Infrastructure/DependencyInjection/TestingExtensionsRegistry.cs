using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation;
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