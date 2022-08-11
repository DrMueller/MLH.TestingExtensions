using System;
using System.Diagnostics;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Models;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Domain.Services.Implementation
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
            Debug.WriteLine(disposedByCode);

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