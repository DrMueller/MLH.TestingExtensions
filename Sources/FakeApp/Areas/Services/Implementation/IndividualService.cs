using System;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Models;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services.Implementation
{
    public class IndividualService : IIndividualService
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Individual LoadIndividual()
        {
            return new Individual("Test1234");
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~IndividualService()
        {
            Dispose(false);
        }
    }
}