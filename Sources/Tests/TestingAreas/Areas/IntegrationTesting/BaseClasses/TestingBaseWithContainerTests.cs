using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.BaseClasses;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.IntegrationTesting.BaseClasses
{
    [TestFixture]
    public class TestingBaseWithContainerTests : TestingBaseWithContainer
    {
        [Test]
        public void FetchingService_WithoutFake_FetchesActualService()
        {
            IIndividualService actualIndividualService = null;

            Assert.DoesNotThrow(
                () =>
                {
                    actualIndividualService = ServiceLocator.GetService<IIndividualService>();
                });

            Assert.IsNotNull(actualIndividualService);
        }

        [Test]
        public void RegisteringFake_RegistersFake()
        {
            var individualServiceMock = new Mock<IIndividualService>();
            RegisterInstance(individualServiceMock.Object);

            var actualIndividualService = ServiceLocator.GetService<IIndividualService>();

            Assert.AreEqual(individualServiceMock.Object, actualIndividualService);
        }
    }
}