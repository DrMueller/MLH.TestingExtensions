namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.Services.Implementation
{
    public class OrganisationService
    {
        private readonly IIndividualServiceFactory _individualServiceFactory;

        public OrganisationService(IIndividualServiceFactory individualServiceFactory)
        {
            _individualServiceFactory = individualServiceFactory;
        }

        public void DoStuffAfterDisposed()
        {
            var indService = _individualServiceFactory.Create();
            indService.Dispose();
            indService.LoadIndividual();
        }

        public void DoStuffWithDisposing()
        {
            // ReSharper disable once UnusedVariable
            using (var indService = _individualServiceFactory.Create())
            {
            }
        }

        public void DoStuffWithoutDisposing()
        {
            // ReSharper disable once UnusedVariable
            var indService = _individualServiceFactory.Create();
        }
    }
}