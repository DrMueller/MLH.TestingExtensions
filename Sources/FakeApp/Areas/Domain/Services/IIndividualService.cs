using System;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Models;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Services
{
    public interface IIndividualService : IDisposable
    {
        Individual LoadIndividual();
    }
}