using System.Reflection;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses.Servants
{
    internal static class ProvisioningServiceFactory
    {
        internal static IContainer Create()
        {
            return ContainerInitializationService.CreateInitializedContainer(
                ContainerConfiguration.CreateFromAssembly(Assembly.GetCallingAssembly()));
        }
    }
}