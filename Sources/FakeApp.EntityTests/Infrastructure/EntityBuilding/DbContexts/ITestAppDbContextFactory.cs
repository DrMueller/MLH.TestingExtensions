using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Contexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts
{
    public interface ITestAppDbContextFactory
    {
        AppDbContext Create();
    }
}