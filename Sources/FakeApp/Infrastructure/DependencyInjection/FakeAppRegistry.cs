using StructureMap;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Infrastructure.DependencyInjection
{
    public class FakeAppRegistry : Registry
    {
        public FakeAppRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<FakeAppRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}