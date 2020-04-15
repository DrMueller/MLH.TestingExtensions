using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.TestingExtensions.Infrastructure.Docker.Services;

namespace Mmu.Mlh.TestingExtensions.Areas.EntityFrameworkTesting.Factories.Implementation
{
    internal class DbContextFactory : IDbContextFactory
    {
        private readonly IDockerContainerStarter _dockerContainerStarter;

        public DbContextFactory(IDockerContainerStarter dockerContainerStarter)
        {
            _dockerContainerStarter = dockerContainerStarter;
        }

        public async Task<TDbContext> CreateAsync<TDbContext>(Func<DbContextOptions<TDbContext>, TDbContext> builder)
            where TDbContext : DbContext
        {
            var dockerContainerResult = await _dockerContainerStarter.StartMsSqlContainerAsync();

            var options = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(dockerContainerResult.ConnectionString)
                .Options;

            var result = builder(options);
            return result;
        }
    }
}
