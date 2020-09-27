using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Contexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts.Implementation
{
    public class TestAppDbContextFactory : ITestAppDbContextFactory
    {
        public AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("Test")
                .Options;

            return new AppDbContext(options);
        }
    }
}