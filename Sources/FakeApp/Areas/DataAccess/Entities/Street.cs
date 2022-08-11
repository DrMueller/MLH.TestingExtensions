using JetBrains.Annotations;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    [PublicAPI]
    public class Street : EntityBase
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
    }
}