using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Contexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Factories
{
    public interface IAppDbContextFactory
    {
        AppDbContext Create();
    }
}
