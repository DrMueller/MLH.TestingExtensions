using Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Services;
using Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Services.Implementation;
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

            For<IDockerContainerStarter>().Use<DockerContainerStarter>().Singleton();
        }
    }
}