using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.TypeConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.HasMany(f => f.Streets).WithOne().IsRequired();

            builder.ToTable("Address", "Core");
        }
    }
}