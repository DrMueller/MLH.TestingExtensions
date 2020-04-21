using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Factories
{
    public static class IntegrationTestContextFactory
    {
        public static IIntegrationTestContext Create(ContainerConfiguration containerConfig)
        {
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            return new IntegrationTestContext(container);
        }

        public static IIntegrationTestContext Create()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(IntegrationTestContextFactory).Assembly);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
            return new IntegrationTestContext(container);
        }
    }
}