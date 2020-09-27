using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.DbContexts;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders.Base;
using Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.Factories;

namespace Mmu.Mlh.TestingExtensions.FakeApp.EntityTests.Infrastructure.EntityBuilding.EntityBuilders
{
    public class StreetBuilder : EntityBuilderBase<Street>
    {
        public const string DefaultStreetName = "Default Street";
        public const int DefaultStreetNumber = 1234;

        public StreetBuilder(IEntityBuilderFactory entityBuilderFactory, ITestAppDbContextFactory appContextFactory) : base(entityBuilderFactory, appContextFactory)
        {
        }

        public StreetBuilder WithStreetName(string streetName)
        {
            Entity.StreetName = streetName;

            return this;
        }

        public StreetBuilder WithStreetNumber(int number)
        {
            Entity.StreetNumber = number;

            return this;
        }

        protected override void InitializePrimitiveValues()
        {
            Entity.StreetNumber = DefaultStreetNumber;
            Entity.StreetName = DefaultStreetName;
        }
    }
}