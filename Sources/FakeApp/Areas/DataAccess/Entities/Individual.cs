using System;
using System.Collections.Generic;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    public class Individual : EntityBase
    {
        public ICollection<Address> Addresses { get; set; }
        public DateTime Birthdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}