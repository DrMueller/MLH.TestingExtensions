using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.TestingAreas.Areas.EntityTesting
{
    [TestFixture]
    public class IndividualBuilderTests
    {
        private ITestAppDbContextFactory _dbContextFactory;
        private IEntityBuilderFactory _entityBuilderFactory;

        [SetUp]
        public void Align()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(
                typeof
                    (IndividualBuilderTests).Assembly);

            var serviceLocator = IntegrationTestContextBuilderFactory
                .StartBuilding(containerConfig)
                .Build()
                .ServiceLocator;

            _entityBuilderFactory = serviceLocator.GetService<IEntityBuilderFactory>();
            _dbContextFactory = serviceLocator.GetService<ITestAppDbContextFactory>();
        }

        [Test]
        public async Task Building_CompleteGraph_AndSaving_PersistsGraph()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var createdIndividual = await individualBuilder
                .WithAddress(
                    config =>
                    {
                        config.WithCity();
                        config.WithCity();
                    })
                .WithAddress()
                .BuildAsync(true);

            // Assert
            await using var dbContext = _dbContextFactory.Create();
            var actualIndividual = await dbContext.Set<Individual>()
                .Include(f => f.Addresses)
                .ThenInclude(f => f.Streets)
                .SingleAsync(f => f.Id == createdIndividual.Id);

            Assert.AreEqual(IndividualBuilder.DefaultBirthdate, actualIndividual.Birthdate);
            Assert.AreEqual(IndividualBuilder.DefaultFirstName, actualIndividual.FirstName);
            Assert.AreEqual(IndividualBuilder.DefaultLastName, actualIndividual.LastName);

            var addresses = actualIndividual.Addresses;

            Assert.AreEqual(2, addresses.Count);
            Assert.IsTrue(addresses.All(adr => adr.Zip == AddressBuilder.DefaultZip));
            Assert.IsTrue(addresses.All(adr => adr.City == AddressBuilder.DefaultCity));

            var firstAddress = addresses.First();
            Assert.AreEqual(2, firstAddress.Streets.Count);
            Assert.IsTrue(firstAddress.Streets.All(str => str.StreetName == StreetBuilder.DefaultStreetName));
            Assert.IsTrue(firstAddress.Streets.All(str => str.StreetNumber == StreetBuilder.DefaultStreetNumber));
        }

        [Test]
        public async Task Building_WithAddress_UsesAddressDefaultValues()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder
                .WithAddress()
                .BuildAsync();

            // Assert
            var actualAddress = actualIndividual.Addresses.Single();
            Assert.AreEqual(AddressBuilder.DefaultCity, actualAddress.City);
            Assert.AreEqual(AddressBuilder.DefaultZip, actualAddress.Zip);
        }

        [Test]
        public async Task Building_WithAddressAndTwoStreets_AddsTwoStreets()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder
                .WithAddress(
                    config =>
                    {
                        config.WithCity();
                        config.WithCity();
                    })
                .BuildAsync();

            // Assert
            var actualAddress = actualIndividual.Addresses.Single();
            Assert.AreEqual(2, actualAddress.Streets.Count);
        }

        [Test]
        public async Task Building_WithAddressAndTwoStreets_AndsSpecificStreetValues_UsesStreetValues()
        {
            // Arrange
            const string StreetName = "Tra1213";
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder
                .WithAddress(
                    config =>
                    {
                        config.WithCity(str => str.WithStreetName(StreetName));
                    })
                .BuildAsync();

            // Assert
            var actualStreet = actualIndividual.Addresses.Single().Streets.Single();
            Assert.AreEqual(StreetName, actualStreet.StreetName);
        }

        [Test]
        public async Task Building_WithoutAdditionalCalls_UsesDefaultValues()
        {
            // Arrange
            var sut = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await sut.BuildAsync();

            // Assert
            Assert.AreEqual(IndividualBuilder.DefaultBirthdate, actualIndividual.Birthdate);
            Assert.AreEqual(IndividualBuilder.DefaultFirstName, actualIndividual.FirstName);
            Assert.AreEqual(IndividualBuilder.DefaultLastName, actualIndividual.LastName);
        }

        [Test]
        public async Task Building_WithoutAdditionalCalls_IDbeingNull()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder.BuildAsync();

            // Assert
            Assert.IsNull(actualIndividual.Id);
        }

        [Test]
        public async Task Building_WithSaving_PersistsEntity()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var returnedIndividual = await individualBuilder.BuildAsync(true);

            // Assert
            await using var dbContext = _dbContextFactory.Create();
            var actualIndividual = await dbContext.FindAsync<Individual>(returnedIndividual.Id);

            Assert.AreEqual(IndividualBuilder.DefaultBirthdate, actualIndividual.Birthdate);
            Assert.AreEqual(IndividualBuilder.DefaultFirstName, actualIndividual.FirstName);
            Assert.AreEqual(IndividualBuilder.DefaultLastName, actualIndividual.LastName);
        }

        [Test]
        public async Task Building_WithSaving_SetsID()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder.BuildAsync(true);

            // Assert
            Assert.IsNotNull(actualIndividual.Id);
        }

        [Test]
        public async Task Building_WithTwoAddresses_AddsTwoAddresses()
        {
            // Arrange
            var individualBuilder = _entityBuilderFactory.Create<IndividualBuilder>();

            // Act
            var actualIndividual = await individualBuilder
                .WithAddress()
                .WithAddress()
                .BuildAsync();

            // Assert
            Assert.AreEqual(2, actualIndividual.Addresses.Count);
        }
    }
}