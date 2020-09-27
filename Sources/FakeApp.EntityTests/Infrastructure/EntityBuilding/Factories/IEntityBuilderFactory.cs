using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories
{
    public interface IEntityBuilderFactory
    {
        T Create<T>() where T : IEntityBuilder;
    }
}