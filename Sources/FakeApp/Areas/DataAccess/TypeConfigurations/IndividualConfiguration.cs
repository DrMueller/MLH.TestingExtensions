using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.TypeConfigurations
{
    public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.Birthdate).IsRequired();
            builder.Property(f => f.FirstName).IsRequired();
            builder.Property(f => f.LastName).IsRequired();
            builder.HasMany(f => f.Addresses).WithOne().IsRequired();

            builder.ToTable("Individual", "Core");
        }
    }
}