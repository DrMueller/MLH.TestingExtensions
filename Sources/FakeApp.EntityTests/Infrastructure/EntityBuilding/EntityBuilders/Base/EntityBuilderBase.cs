using System.Threading.Tasks;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base
{
    public abstract class EntityBuilderBase<TEntity> : IEntityBuilder<TEntity>
        where TEntity : class, new()
    {
        protected IEntityBuilderFactory EntityBuilderFactory { get; }
        private readonly ITestAppDbContextFactory _appContextFactory;
        protected TEntity Entity { get; }

        protected EntityBuilderBase(
            IEntityBuilderFactory entityBuilderFactory,
            ITestAppDbContextFactory appContextFactory)
        {
            EntityBuilderFactory = entityBuilderFactory;
            _appContextFactory = appContextFactory;
            Entity = new TEntity();
            // ReSharper disable once VirtualMemberCallInConstructor
            InitializePrimitiveValues();
        }

        public async Task<TEntity> BuildAsync(bool doSave = false)
        {
            await CreateNavigationEntitiesAsync();

            if (!doSave)
            {
                return Entity;
            }

            await using var appContext = _appContextFactory.Create();
            appContext.Add(Entity);
            await appContext.SaveChangesAsync();

            return Entity;
        }

        protected virtual Task CreateNavigationEntitiesAsync()
        {
            return Task.CompletedTask;
        }

        protected abstract void InitializePrimitiveValues();
    }
}