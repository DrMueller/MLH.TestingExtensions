using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    [PublicAPI]
    public class Individual : EntityBase
    {
        public ICollection<Address> Addresses { get; set; }
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}