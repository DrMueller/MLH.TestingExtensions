using System.Collections.Generic;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Models
{
    public class Organisation
    {
        public IReadOnlyCollection<string> Addresses { get; }

        public Organisation(IReadOnlyCollection<string> addresses)
        {
            Addresses = addresses;
        }
    }
}