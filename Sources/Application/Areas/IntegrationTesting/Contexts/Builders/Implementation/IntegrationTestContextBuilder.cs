using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models.Implementation;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders.Implementation
{
    // Lamar doesn't like if we change the Container at runtime, therefore we have to pass everything on creation
    // See: https://jasperfx.github.io/lamar/documentation/ioc/registration/changing-configuration-at-runtime/
    public class IntegrationTestContextBuilder : IIntegrationTestContextBuilder
    {
        private readonly ContainerConfiguration _containerConfig;
        private List<ServiceDescriptor> _serviceDescriptors;

        internal IntegrationTestContextBuilder(ContainerConfiguration containerConfig)
        {
            _containerConfig = containerConfig;
            _serviceDescriptors = new List<ServiceDescriptor>();
        }

        public IIntegrationTestContext Build()
        {
            var container = ServiceProvisioningInitializer.CreateContainer(
                _containerConfig,
                _serviceDescriptors);

            return new IntegrationTestContext(container);
        }

        public IIntegrationTestContextBuilder RegisterInstance<TService>(TService instance)
            where TService : class
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), instance));
            return this;
        }
    }
}