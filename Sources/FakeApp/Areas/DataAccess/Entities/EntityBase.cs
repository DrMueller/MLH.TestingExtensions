using JetBrains.Annotations;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities
{
    [PublicAPI]
    public class EntityBase
    {
        public long? Id { get; set; }
    }
}