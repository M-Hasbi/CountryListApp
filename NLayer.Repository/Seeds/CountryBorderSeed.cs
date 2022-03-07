using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    internal class CountryBorderSeed : IEntityTypeConfiguration<CountryBorder>
    {
        public void Configure(EntityTypeBuilder<CountryBorder> builder)
        {
            builder.HasData(new CountryBorder
            {
                Id = 1,
                CountryId = 1,
                Names = { "USA", "CAN" },
                CreatedDate = DateTime.Now


            },
            new CountryBorder
            {
                Id = 2,
                CountryId = 2,
                Names = { "USA", "MEX" },
                CreatedDate = DateTime.Now


            },
             new CountryBorder
             {
                 Id = 3,
                 CountryId = 3,
                 Names = { "USA", "MEX", "BLZ" },
                 CreatedDate = DateTime.Now


             },
               new CountryBorder
               {
                   Id = 4,
                   CountryId = 4,
                   Names = { "USA", "MEX", "GTM"},
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 5,
                   CountryId = 5,
                   Names = { "USA", "MEX", "GTM" ,"SLV"},
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 6,
                   CountryId = 6,
                   Names = { "USA", "MEX", "GTM","HND" },
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 7,
                   CountryId = 7,
                   Names = { "USA", "MEX", "GTM", "HND","NIC" },
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 8,
                   CountryId = 8,
                   Names = { "USA", "MEX", "GTM", "HND", "NIC","CRI" },
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 9,
                   CountryId = 9,
                   Names = { "USA", "MEX", "GTM", "HND", "NIC", "CRI","PAN" },
                   CreatedDate = DateTime.Now


               }







               );

        }
    }
}
