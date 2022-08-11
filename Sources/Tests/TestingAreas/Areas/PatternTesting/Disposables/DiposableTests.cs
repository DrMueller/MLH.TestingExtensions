using Mmu.Mlh.TestingExtensions.Areas.PatternTesting.Disposables;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Services;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Services.Implementation;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.PatternTesting.Disposables
{
    [TestFixture]
    public class DiposableTests
    {
        [Test]
        public void DisposingObjects_AssertsDisposed()
        {
            // Arrange
            var indServiceDisposable = DisposableTestFactory.Create(() => new Mock<IIndividualService>().Object);
            var indServiceFactoryMock = new Mock<IIndividualServiceFactory>();
            indServiceFactoryMock.Setup(f => f.Create()).Returns(indServiceDisposable.TestObject);

            var orgService = new OrganisationService(indServiceFactoryMock.Object);

            // Act
            orgService.DoStuffWithDisposing();

            // Assert
            Assert.DoesNotThrow(() => indServiceDisposable.AssertDisposed());
        }

        [Test]
        public void NotDisposingObject_FailsAssertion()
        {
            // Arrange
            var indServiceDisposable = DisposableTestFactory.Create(() => new Mock<IIndividualService>().Object);
            var indServiceFactoryMock = new Mock<IIndividualServiceFactory>();
            indServiceFactoryMock.Setup(f => f.Create()).Returns(indServiceDisposable.TestObject);

            var orgService = new OrganisationService(indServiceFactoryMock.Object);

            // Act
            orgService.DoStuffWithoutDisposing();

            // Assert
            var actualException = Assert.Throws<AssertionException>(() => indServiceDisposable.AssertDisposed());
            Assert.AreEqual(AssertionErrorMessages.ObjectNotDisposedErrorMessage, actualException!.Message);
        }

        [Test]
        public void UsingObject_AlreadyBeingDisposed_FailsAssertion()
        {
            // Arrange
            var indServiceDisposable = DisposableTestFactory.Create(() => new Mock<IIndividualService>().Object);
            var indServiceFactoryMock = new Mock<IIndividualServiceFactory>();
            indServiceFactoryMock.Setup(f => f.Create()).Returns(indServiceDisposable.TestObject);

            var orgService = new OrganisationService(indServiceFactoryMock.Object);

            // Act
            orgService.DoStuffAfterDisposed();

            // Assert
            var actualException = Assert.Throws<AssertionException>(() => indServiceDisposable.AssertDisposed());
            Assert.AreEqual(AssertionErrorMessages.MemberCalledAfterDisposedErrorMessage, actualException!.Message);
        }
    }
}