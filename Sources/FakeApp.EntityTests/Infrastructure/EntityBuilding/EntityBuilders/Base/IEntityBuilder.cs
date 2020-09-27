using System.Threading.Tasks;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base
{
    // Marker interface, which makes the resolving via IEntityBuilderFactory more readable
    public interface IEntityBuilder
    {
    }

    public interface IEntityBuilder<TEntity> : IEntityBuilder
        where TEntity : class, new()
    {
        Task<TEntity> BuildAsync(bool doSave = false);
    }
}