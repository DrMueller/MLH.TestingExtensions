using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DataModels;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<IndividualDataModel> Individuals { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionStringProvider = ServiceLocatorSingleton.Instance.GetService<IConnectionStringProvider>();
            var connectionString = connectionStringProvider.ProvideConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw());
            base.OnConfiguring(optionsBuilder);
        }
    }
}