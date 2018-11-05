using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models
{
    public class Individual
    {
        public const string UnkownLastname = "UNKNOWN";
        public static DateTime UnkownBirthdate => DateTime.MinValue;
        public DateTime? BirthDate { get; }
        public string FirstName { get; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(LastName))
                {
                    return FirstName;
                }

                return FirstName + " " + LastName;
            }
        }

        public string LastName { get; }

        public Individual(string firstName, string lastName, DateTime? birthDate)
        {
            Guard.StringNotNullOrEmpty(() => firstName);

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Individual(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = UnkownBirthdate;
        }

        public Individual(string firstName)
        {
            FirstName = firstName;
            LastName = UnkownLastname;
            BirthDate = UnkownBirthdate;
        }
    }
}