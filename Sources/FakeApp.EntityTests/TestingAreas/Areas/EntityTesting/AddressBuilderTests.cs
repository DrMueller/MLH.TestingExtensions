using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.TestingAreas.Areas.EntityTesting
{
    [TestFixture]
    public class AddressBuilderTests
    {
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
        }

        [Test]
        public async Task Building_WithoutAdditionalCalls_UsesDefaultValues()
        {
            // Arrange
            var sut = _entityBuilderFactory.Create<AddressBuilder>();

            // Act
            var actualAddress = await sut.BuildAsync();

            // Assert
            Assert.AreEqual(AddressBuilder.DefaultCity, actualAddress.City);
            Assert.AreEqual(AddressBuilder.DefaultZip, actualAddress.Zip);
        }

        [Test]
        public async Task Building_WithPassedValues_UsesPassedValues()
        {
            // Arrange
            const string City = "City1313";
            const int Zip = 12252;

            var sut = _entityBuilderFactory.Create<AddressBuilder>();

            // Act
            var actualAddress = await sut
                .WithZip(Zip)
                .WithCity(City)
                .BuildAsync();

            // Assert
            Assert.AreEqual(City, actualAddress.City);
            Assert.AreEqual(Zip, actualAddress.Zip);
        }
    }
}