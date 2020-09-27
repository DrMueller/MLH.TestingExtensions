using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Contexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts.Factories.Implementation
{
    public class AppDbContextFactory : IAppDbContextFactory
    {
        public AppDbContext Create()
        {
            const string ConnectionString = "server=localhost\\sqlexpress;database=FakeDataAccess;Trusted_Connection=True;Max Pool Size = 500;Pooling = True; MultipleActiveResultSets = True";

            var options = new DbContextOptionsBuilder()
                .UseSqlServer(ConnectionString)
                .Options;

            return new AppDbContext(options);
        }
    }
}
