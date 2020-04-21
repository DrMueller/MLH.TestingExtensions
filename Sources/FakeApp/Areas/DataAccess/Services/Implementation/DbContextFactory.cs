using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Services.Implementation
{
    public class DbContextFactory : IDbContextFactory
    {
        public AppDbContext Create()
        {
            return null;
        }
    }
}