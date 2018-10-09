using System;
using Mmu.Mlh.TestingExtensions.Areas.Common.BasesClasses;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.ConstructorTesting
{
    public class ConstructorTests : TestingBaseWithContainer
    {
        [Test]
        public void TestingConstructor_UsingConstructorWith2Arguments_UsesConstructorWithTwoArguments()
        {
            const string FirstName = "Steven";
            const string LastName = "Austin";

            ConstructorTestBuilderFactory.Constructing<Individual>()
                .UsingConstructorWithParameters(typeof(string), typeof(string))
                .WithArgumentValues(FirstName, LastName)
                .Maps()
                .ToProperty(f => f.BirthDate).WithValue(Individual.UnkownBirthdate)
                .ToProperty(f => f.LastName).WithValue(LastName)
                .ToProperty(f => f.FirstName).WithValue(FirstName)
                .BuildMaps()
                .Assert();
        }

        [Test]
        public void TestingConstructor_UsingDefaultConstructor_UsesConstructorWithLeastArguments()
        {
            const string FirstName = "Steven";

            ConstructorTestBuilderFactory.Constructing<Individual>()
                .UsingDefaultConstructor()
                .WithArgumentValues(FirstName)
                .Maps()
                .ToProperty(f => f.BirthDate).WithValue(Individual.UnkownBirthdate)
                .ToProperty(f => f.LastName).WithValue(Individual.UnkownLastname)
                .ToProperty(f => f.FirstName).WithValue(FirstName)
                .BuildMaps()
                .Assert();
        }

        [Test]
        public void TestingConstructor_WhenConfigShouldFail_ButDoesnt_Throws()
        {
            Assert.Throws<AssertionException>(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Test1", "Test2", new DateTime(1986, 12, 29)).Fails()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WhenConfigShouldntFail_ButDoes_Throws()
        {
            Assert.Throws<AssertionException>(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(null, "Test2", new DateTime(1986, 12, 29)).Succeeds()
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
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(FirstName, LastName, birthdate)
                        .Maps()
                        .ToProperty(f => f.FullName).WithValue(ExpectedFullName)
                        .ToProperty(f => f.BirthDate).WithValue(birthdate)
                        .BuildMaps()
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
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(FirstName, LastName, birthdate)
                        .Maps()
                        .ToProperty(f => f.FullName).WithValue(ExpectedFullNameBeingWrong)
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void TestingConstructor_WithValidConfig_DoesNotThrow()
        {
            const string FirstName = "Matthias";

            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(FirstName, null, null).Succeeds()
                        .WithArgumentValues(null, null, null).Fails()
                        .WithArgumentValues(FirstName, null, null)
                        .Maps()
                        .ToProperty(f => f.FirstName).WithValue(FirstName)
                        .ToProperty(f => f.FullName).WithValue(FirstName)
                        .ToProperty(f => f.BirthDate).WithValue(null)
                        .BuildMaps()
                        .Assert();
                });
        }
    }
}