using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models
{
    public interface IIntegrationTestContext
    {
        IServiceLocator ServiceLocator { get; }
    }
}