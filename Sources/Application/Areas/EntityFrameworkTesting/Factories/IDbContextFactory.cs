using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mmu.Mlh.TestingExtensions.Areas.EntityFrameworkTesting.Factories
{
    public interface IDbContextFactory
    {
        Task<TDbContext> CreateAsync<TDbContext>(Func<DbContextOptions<TDbContext>, TDbContext> builder)
            where TDbContext : DbContext;
    }
}