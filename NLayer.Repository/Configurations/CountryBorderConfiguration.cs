using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configurations
{
    internal class CountryBorderConfiguration : IEntityTypeConfiguration<CountryBorder>
    {
        public void Configure(EntityTypeBuilder<CountryBorder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Names).IsRequired().HasMaxLength(200);

            builder.ToTable("CountryBorders");

            builder.HasOne(x => x.Country).WithMany(x => x.CountryBorders).HasForeignKey(x => x.CountryId);
        }
    }
}
