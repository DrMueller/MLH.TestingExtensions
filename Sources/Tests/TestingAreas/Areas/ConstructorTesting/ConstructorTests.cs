using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services.Implementation.PropertyAsserters.Servants;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Models;
using NUnit.Framework;

namespace Mmu.Mlh.TestingExtensions.Tests.TestingAreas.Areas.ConstructorTesting
{
    public class ConstructorTests
    {
        [Test]
        public void ComparingConstructorNotNull_ToNullValue_DoesThrow()
        {
            const string ActualLastName = "Müller";
            var expexctedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(null, ActualLastName);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Matthias", ActualLastName, DateTime.Now)
                        .Maps()
                        .ToProperty(f => f.BirthDate).WithValue(DateTime.Now)
                        .ToProperty(f => f.FirstName).WithValue("Matthias")
                        .ToProperty(f => f.LastName).WithValue(null)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expexctedMessageEnding));
        }

        [Test]
        public void ComparingConstructorNotNull_ToNullValueCollection_DoesThrow()
        {
            var actualList = new List<string>();
            var expexctedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(null, actualList);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(actualList)
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(null)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expexctedMessageEnding));
        }

        [Test]
        public void ComparingConstructorNull_ToNotNullValue_DoesThrow()
        {
            var expectedDate = new DateTime(1986, 12, 29);
            var expectedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(expectedDate, null);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Matthias", "Müller", null)
                        .Maps()
                        .ToProperty(f => f.BirthDate).WithValue(expectedDate)
                        .ToProperty(f => f.FirstName).WithValue("Matthias")
                        .ToProperty(f => f.LastName).WithValue("Müller")
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expectedMessageEnding));
        }

        [Test]
        public void ComparingConstructorNull_ToNotNullValueCollection_DoesThrow()
        {
            var expectedList = new List<string>();
            var expexctedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(expectedList, null);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(null)
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(expectedList)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expexctedMessageEnding));
        }

        [Test]
        public void ComparingConstructorNullString_ToNotNullString_DoesThrow()
        {
            const string ExpectedLastname = "Müller";
            var expectedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(ExpectedLastname, null);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Matthias", null, null)
                        .Maps()
                        .ToProperty(f => f.BirthDate).WithValue(null)
                        .ToProperty(f => f.FirstName).WithValue("Matthias")
                        .ToProperty(f => f.LastName).WithValue(ExpectedLastname)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expectedMessageEnding));
        }

        [Test]
        public void ComparingTwoNullValueCollections_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(null)
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(null)
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void ComparingTwoNullValues_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues("Matthias", "Müller", null)
                        .Maps()
                        .ToProperty(f => f.BirthDate).WithValue(null)
                        .ToProperty(f => f.FirstName).WithValue("Matthias")
                        .ToProperty(f => f.LastName).WithValue("Müller")
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void ConstructingWithParams_PassingMultipleValues_MapsToCollectionWithPassedValues()
        {
            var expectedStreets = new[]
            {
                "Fakestreet",
                "Another Fakestreet",
                "Downtown Fakestreet"
            };

            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Address>()
                        .UsingDefaultConstructor()

                        // ReSharper disable once CoVariantArrayConversion
                        .WithArgumentValues(expectedStreets)
                        .Maps()
                        .ToProperty(f => f.Streets).WithValues(expectedStreets)
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void ConstructingWithParams_PassingNoValue_MapsToCollectionWithoutValues()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Address>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues()
                        .Maps()
                        .ToProperty(f => f.Streets).WithValues(Array.Empty<string>())
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void ConstructingWithParams_PassingOneValue_MapsToCollectionWithPassedValue()
        {
            var expectedStreets = new[]
            {
                "Fakestreet"
            };

            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Address>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(expectedStreets.Single())
                        .Maps()
                        .ToProperty(f => f.Streets).WithValues(expectedStreets)
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void PassingCollectionValues_MappingPropertyToCollectionWithDifferentValues_Throws()
        {
            var actualList = new List<string> { "Test1", "Test2" };
            var expectedList = new List<string> { "Other1", "Test2" };
            var expexctedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(expectedList, actualList);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(actualList)
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(expectedList)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expexctedMessageEnding));
        }

        [Test]
        public void PassingCollectionValues_MappingPropertyToCollectionWithSameValues_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(new List<string> { "Test1", "Test2" })
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(new List<string> { "Test2", "Test1" })
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void PassingEmptyCollection_MappingPropertyToEmptyCollection_DoesNotThrow()
        {
            Assert.DoesNotThrow(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Organisation>()
                        .UsingDefaultConstructor()
                        .WithArgumentValues(new List<string>())
                        .Maps()
                        .ToProperty(f => f.Addresses).WithValues(new List<string>())
                        .BuildMaps()
                        .Assert();
                });
        }

        [Test]
        public void UsingConstructorWith2Arguments_UsesConstructorWithTwoArguments()
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
        public void UsingDefaultConstructor_UsesConstructorWithLeastArguments()
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
        public void WhenConfigShouldFail_ButDoesnt_Throws()
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
        public void WhenConfigShouldntFail_ButDoes_Throws()
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
        public void WithMappingToProperty_MappingBeingCorrect_Works()
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
        public void WithMappingToProperty_MappingBeingIncorrect_Throws()
        {
            const string FirstName = "Steve";
            const string LastName = "Austin";
            var birthdate = new DateTime(1964, 12, 18);
            const string ExpectedFullNameBeingWrong = "Other String";
            const string ActualCorrectFullName = "Steve Austin";

            var expexctedMessageEnding = FailingMessageFactory.CreateNotEqualMessage(ExpectedFullNameBeingWrong, ActualCorrectFullName);

            Assert.That(
                () =>
                {
                    ConstructorTestBuilderFactory.Constructing<Individual>()
                        .UsingConstructorWithParameters(typeof(string), typeof(string), typeof(DateTime?))
                        .WithArgumentValues(FirstName, LastName, birthdate)
                        .Maps()
                        .ToProperty(f => f.FullName).WithValue(ExpectedFullNameBeingWrong)
                        .BuildMaps()
                        .Assert();
                },
                Throws.TypeOf<AssertionException>()
                    .And.Message.EndsWith(expexctedMessageEnding));
        }

        [Test]
        public void WithValidConfig_DoesNotThrow()
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