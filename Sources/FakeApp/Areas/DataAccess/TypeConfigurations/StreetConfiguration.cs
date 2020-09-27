using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Entities;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.TypeConfigurations
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.StreetName).IsRequired();
            builder.Property(f => f.StreetNumber).IsRequired();

            builder.ToTable("Street", "Core");
        }
    }
}