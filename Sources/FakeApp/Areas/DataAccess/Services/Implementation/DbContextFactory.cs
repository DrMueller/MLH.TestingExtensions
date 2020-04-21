using System;
using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Services.Implementation
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContextFactory()
        {
            
        }

        public AppDbContext Create()
        {
            return null;
        }
    }
}
