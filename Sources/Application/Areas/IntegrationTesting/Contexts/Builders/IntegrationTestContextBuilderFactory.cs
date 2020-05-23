using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders
{
    public static class IntegrationTestContextBuilderFactory
    {
        public static IIntegrationTestContextBuilder StartBuilding(ContainerConfiguration containerConfig = null)
        {
            containerConfig = containerConfig ?? ContainerConfiguration.CreateFromAssembly(typeof(IntegrationTestContextBuilder).Assembly);
            return new IntegrationTestContextBuilder(containerConfig);
        }
    }
}