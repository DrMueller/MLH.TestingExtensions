using Lamar;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models.Implementation
{
    internal class IntegrationTestContext : IIntegrationTestContext
    {
        public IServiceLocator ServiceLocator { get; }

        public IntegrationTestContext(IServiceContext serviceContext)
        {
            ServiceLocator = serviceContext.GetInstance<IServiceLocator>();
        }
    }
}