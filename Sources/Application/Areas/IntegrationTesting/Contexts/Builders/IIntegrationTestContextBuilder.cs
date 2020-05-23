using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Models;

namespace Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders
{
    // Lamar doesn't like if we change the Container at runtime, therefore we have to pass everything on creation
    // See: https://jasperfx.github.io/lamar/documentation/ioc/registration/changing-configuration-at-runtime/
    public interface IIntegrationTestContextBuilder
    {
        IIntegrationTestContext Build();

        IIntegrationTestContextBuilder RegisterInstance<TService>(TService instance)
            where TService : class;
    }
}