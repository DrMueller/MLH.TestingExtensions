using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Factories;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.IntegrationTesting.BaseClasses
{
    [TestFixture]
    public class IntegrationTestContextTests
    {
        [Test]
        public void FetchingService_WithoutFake_FetchesActualService()
        {
            var context = IntegrationTestContextFactory.Create();

            Assert.DoesNotThrow(
                () =>
                {
                    var actualIndividualService = context.ServiceLocator.GetService<IIndividualService>();
                    Assert.IsNotNull(actualIndividualService);
                });
        }

        [Test]
        public void RegisteringFake_RegistersFake()
        {
            var context = IntegrationTestContextFactory.Create();

            var individualServiceMock = new Mock<IIndividualService>();
            context.RegisterInstance(individualServiceMock.Object);

            var actualIndividualService = context.ServiceLocator.GetService<IIndividualService>();

            Assert.AreEqual(individualServiceMock.Object, actualIndividualService);
        }
    }
}