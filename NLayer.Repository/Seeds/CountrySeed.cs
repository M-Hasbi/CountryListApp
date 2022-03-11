using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class CountrySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "CAN" },
                new Country { Id = 2, Name = "MEX" },
                new Country { Id = 3, Name = "BLZ" },
                new Country { Id = 4, Name = "GTM" },
                new Country { Id = 5, Name = "SLV" },
                new Country { Id = 6, Name = "HND" },
                new Country { Id = 7, Name = "NIC" },
                new Country { Id = 8, Name = "CRI" },
                new Country { Id = 9, Name = "PAN" }
                );
        }
    }
}
