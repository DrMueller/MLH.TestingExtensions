using System;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using StructureMap;

namespace Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses.Servants
{
    internal static class ProvisioningServiceFactory
    {
        internal static IContainer Create()
        {
            return ContainerInitializationService.CreateInitializedContainer(CreateParameters());
        }

        private static AssemblyParameters CreateParameters()
        {
            var assembly = Assembly.GetCallingAssembly();
            var namespaceChunks = assembly.FullName.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Take(2);
            var nameSpaceStart = string.Join(".", namespaceChunks);

            return new AssemblyParameters(assembly, nameSpaceStart);
        }
    }
}