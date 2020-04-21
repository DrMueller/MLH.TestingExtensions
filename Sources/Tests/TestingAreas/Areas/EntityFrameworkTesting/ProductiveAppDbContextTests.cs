using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DataModels;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.DbContexts;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.EntityFrameworkTesting
{
    [TestFixture]
    public class ProductiveAppDbContextTests
    {
        [Test]
        public async Task AddingAndLoadingIndividuals_Works()
        {
            // Arrange
            var appDbContext = new AppDbContext();
            var ind = new IndividualDataModel
            {
                Birthdate = new DateTime(1986, 12, 29),
                FirstName = "Matthias",
                LastName = "Müller"
            };

            // Act
            await appDbContext.Individuals.AddAsync(ind);
            await appDbContext.SaveChangesAsync();
            
            var individuals = await appDbContext.Individuals.ToListAsync();

            // Assert
            CollectionAssert.IsNotEmpty(individuals);
        }
    }
}