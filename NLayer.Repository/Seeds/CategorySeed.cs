using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {


            builder.HasData(
                new Country { Id = 1, Name = "Kalemler" },
                new Country { Id = 2, Name = "Kitaplar" },
                new Country { Id = 3, Name = "Defterler" });
        }
    }
}
