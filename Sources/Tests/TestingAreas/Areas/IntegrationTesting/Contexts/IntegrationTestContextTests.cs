using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.TestingExtensions.Areas.IntegrationTesting.Contexts.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.IntegrationTesting.Contexts
{
    [TestFixture]
    public class IntegrationTestContextTests
    {
        [Test]
        public void FetchingService_WithoutFake_FetchesActualService()
        {
            var context = IntegrationTestContextBuilderFactory.StartBuilding(CreateContext()).Build();

            Assert.DoesNotThrow(
                () =>
                {
                    var actualIndividualService = context.ServiceLocator.GetService<IIndividualService>();
                    Assert.IsNotNull(actualIndividualService);
                });
        }

        [Test]
        public void RegisteringInstance_RegistersInstance()
        {
            var individualServiceMock = Mock.Of<IIndividualService>();

            var context = IntegrationTestContextBuilderFactory
                .StartBuilding(CreateContext())
                .RegisterInstance(individualServiceMock)
                .Build();

            var actualIndividualService = context.ServiceLocator.GetService<IIndividualService>();

            Assert.AreEqual(individualServiceMock, actualIndividualService);
        }

        private static ContainerConfiguration CreateContext()
        {
            return ContainerConfiguration.CreateFromAssembly(typeof(IntegrationTestContextTests).Assembly);
        }
    }
}