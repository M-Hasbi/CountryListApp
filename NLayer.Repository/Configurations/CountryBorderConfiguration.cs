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
            builder.Property(x => x.Name1).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name2).HasMaxLength(200);
            builder.Property(x => x.Name3).HasMaxLength(200);
            builder.Property(x => x.Name4).HasMaxLength(200);
            builder.Property(x => x.Name5).HasMaxLength(200);
            builder.Property(x => x.Name6).HasMaxLength(200);
            builder.Property(x => x.Name7).HasMaxLength(200);
            builder.Property(x => x.Name8).HasMaxLength(200);
            builder.Property(x => x.Name9).HasMaxLength(200);

            builder.ToTable("CountryBorders");

            builder.HasOne(x => x.Country).WithMany(x => x.CountryBorders).HasForeignKey(x => x.CountryId);
        }
    }
}
