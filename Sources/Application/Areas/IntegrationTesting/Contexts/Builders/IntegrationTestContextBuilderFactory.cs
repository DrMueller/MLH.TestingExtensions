using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders
{
    public static class IntegrationTestContextBuilderFactory
    {
        public static IIntegrationTestContextBuilder StartBuilding(ContainerConfiguration containerConfig)
        {
            return new IntegrationTestContextBuilder(containerConfig);
        }
    }
}