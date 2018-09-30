using Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.TestingServiceProvisioning
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
                    actualIndividualService = ProvisioningService.GetService<IIndividualService>();
                });

            Assert.IsNotNull(actualIndividualService);
        }

        [Test]
        public void RegisteringFake_RegistersFake()
        {
            var individualServiceMock = new Mock<IIndividualService>();
            RegisterInstance(individualServiceMock.Object);

            var actualIndividualService = ProvisioningService.GetService<IIndividualService>();

            Assert.AreEqual(individualServiceMock.Object, actualIndividualService);
        }
    }
}