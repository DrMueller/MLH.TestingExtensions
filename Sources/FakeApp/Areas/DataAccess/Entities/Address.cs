using System.Collections.Generic;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    public class Address : EntityBase
    {
        public string City { get; set; }
        public ICollection<Street> Streets { get; set; }
        public int Zip { get; set; }
    }
}