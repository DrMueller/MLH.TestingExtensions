using System;
using Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.ConstructorTesting
{
    public class ConstructorTests : TestingBaseWithContainer
    {
        private ICtorTestBuilderFactory _ctorBuilderFactory;

        [Test]
        public void TestingConstructor_UsingConstructorWith2Arguments_UsesConstructorWithTwoArguments()
        {
            const string FirstName = "Steven";
            const string LastName = "Austin";

            _ctorBuilderFactory.ForType<Individual>()
                .ForConstructorWithParams(typeof(string), typeof(string))
                .WithArgumentValues(FirstName, LastName)
                .MapsToProperty(f => f.BirthDate).WithValue(Individual.UnkownBirthdate)
                .MapsToProperty(f => f.LastName).WithValue(LastName)
                .MapsToProperty(f => f.FirstName).WithValue(FirstName)
                .Succeeds()
                .Build()
                .Assert();
        }

        [Test]
        public void TestingConstructor_UsingDefaultConstructor_UsesConstructorWithLeastArguments()
        {
            const string FirstName = "Steven";

            _ctorBuilderFactory.ForType<Individual>()
                .ForDefaultConstructor()
                .WithArgumentValues(FirstName)
                .MapsToProperty(f => f.BirthDate).WithValue(Individual.UnkownBirthdate)
                .MapsToProperty(f => f.LastName).WithValue(Individual.UnkownLastname)
                .MapsToProperty(f => f.FirstName).WithValue(FirstName)
                .Succeeds()
                .Build()
                .Assert();
        }

        [Test]
        public void TestingConstructor_WhenConfigDoesntFail_ButDoes_Throws()
        {
            Assert.Throws<AssertionException>(
                () =>
                {
                    _ctorBuilderFactory.ForType<Individual>()
                        .ForConstructorWithParams(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(null, "Test2", new DateTime(1986, 12, 29)).Succeeds()
                        .Build()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WhenConfigShouldFail_ButDoesnt_Throws()
        {
            Assert.Throws<AssertionException>(
                () =>
                {
                    _ctorBuilderFactory.ForType<Individual>()
                        .ForConstructorWithParams(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Test1", "Test2", new DateTime(1986, 12, 29)).Fails()
                        .Build()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WithMappingToProperty_MappingBeingCorrect_Works()
        {
            const string FirstName = "Steven";
            const string LastName = "Austin";
            var birthdate = new DateTime(1964, 12, 18);
            const string ExpectedFullName = FirstName + " " + LastName;

            Assert.DoesNotThrow(
                () =>
                {
                    _ctorBuilderFactory.ForType<Individual>()
                        .ForConstructorWithParams(typeof(string), typeof(string), typeof(DateTime))
                        .WithArgumentValues(FirstName, LastName, birthdate)
                        .MapsToProperty(f => f.FullName).WithValue(ExpectedFullName)
                        .MapsToProperty(f => f.BirthDate).WithValue(birthdate)
                        .Succeeds()
                        .Build()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WithMappingToProperty_MappingBeingIncorrect_Throws()
        {
            const string FirstName = "Steven";
            const string LastName = "Austin";
            var birthdate = new DateTime(1964, 12, 18);
            const string ExpectedFullNameBeingWrong = "Other String";

            Assert.Throws<AssertionException>(
                () =>
                {
                    _ctorBuilderFactory.ForType<Individual>()
                        .ForDefaultConstructor()
                        .WithArgumentValues(FirstName, LastName, birthdate)
                        .MapsToProperty(f => f.FullName).WithValue(ExpectedFullNameBeingWrong)
                        .Succeeds()
                        .Build()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WithValidConfig_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    _ctorBuilderFactory.ForType<Individual>()
                        .ForConstructorWithParams(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(null, null, null).Fails()
                        .WithArgumentValues(null, "Test2", new DateTime(1986, 12, 29)).Fails()
                        .WithArgumentValues("Test1", "Test2", null).Succeeds()
                        .Build()
                        .Assert();
                });
        }

        protected override void OnSetUp()
        {
            _ctorBuilderFactory = ProvisioningService.GetService<ICtorTestBuilderFactory>();
        }
    }
}