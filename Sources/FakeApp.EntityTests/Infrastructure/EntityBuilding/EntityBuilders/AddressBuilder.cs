using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders
{
    public class AddressBuilder : EntityBuilderBase<Address>
    {
        public const string DefaultCity = "Tra";
        public const int DefaultZip = 1234;
        private IList<StreetBuilder> _streetBuilders = new List<StreetBuilder>();

        public AddressBuilder(IEntityBuilderFactory entityBuilderFactory, ITestAppDbContextFactory appContextFactory) : base(entityBuilderFactory, appContextFactory)
        {
        }

        public AddressBuilder WithCity(Action<StreetBuilder> config = null)
        {
            var streetBuilder = EntityBuilderFactory.Create<StreetBuilder>();
            _streetBuilders.Add(streetBuilder);

            config?.Invoke(streetBuilder);

            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            Entity.City = city;

            return this;
        }

        public AddressBuilder WithZip(int zip)
        {
            Entity.Zip = zip;

            return this;
        }

        protected override async Task CreateNavigationEntitiesAsync()
        {
            var builderTasks = _streetBuilders.Select(sb => sb.BuildAsync());
            Entity.Streets = await Task.WhenAll(builderTasks);
        }

        protected override void InitializePrimitiveValues()
        {
            Entity.City = DefaultCity;
            Entity.Zip = DefaultZip;
        }
    }
}