using System.Collections.Generic;
using JetBrains.Annotations;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    [PublicAPI]
    public class Address : EntityBase
    {
        public string City { get; set; }
        public ICollection<Street> Streets { get; set; }
        public int Zip { get; set; }
    }
}