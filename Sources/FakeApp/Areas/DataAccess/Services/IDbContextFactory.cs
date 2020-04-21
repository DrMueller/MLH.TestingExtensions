using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Services
{
    public interface IDbContextFactory
    {
        AppDbContext Create();
    }
}