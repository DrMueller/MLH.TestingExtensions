using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services.Implementation
{
    public class IndividualService : IIndividualService
    {
        public Individual LoadIndividual()
        {
            return new Individual("Test1234");
        }
    }
}