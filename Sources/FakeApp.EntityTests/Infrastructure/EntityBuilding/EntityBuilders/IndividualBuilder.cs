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
    public class IndividualBuilder : EntityBuilderBase<Individual>
    {
        public static readonly DateTime DefaultBirthdate = new DateTime(1986, 12, 29);
        public const string DefaultFirstName = "Matthias";
        public const string DefaultLastName = "Müller";

        private readonly IList<AddressBuilder> _addressBuilders = new List<AddressBuilder>();


        protected override async Task CreateNavigationEntitiesAsync()
        {
            var builderTasks = _addressBuilders.Select(sb => sb.BuildAsync());
            Entity.Addresses = await Task.WhenAll(builderTasks);
        }


        public IndividualBuilder WithAddress(Action<AddressBuilder> config = null)
        {
            var addressBuilder = EntityBuilderFactory.Create<AddressBuilder>();
            _addressBuilders.Add(addressBuilder);

            config?.Invoke(addressBuilder);

            return this;
        }

        protected override void InitializePrimitiveValues()
        {
            Entity.Birthdate = DefaultBirthdate;
            Entity.LastName = DefaultLastName;
            Entity.FirstName = DefaultFirstName;
        }

        public IndividualBuilder(IEntityBuilderFactory entityBuilderFactory, ITestAppDbContextFactory appContextFactory) : base(entityBuilderFactory, appContextFactory)
        {
        }
    }
}
