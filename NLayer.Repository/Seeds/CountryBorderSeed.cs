using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Seeds
{
    public class CountryBorderSeed : IEntityTypeConfiguration<CountryBorder>
    {
        public void Configure(EntityTypeBuilder<CountryBorder> builder)
        {
            builder.HasData(new CountryBorder
            {
                Id = 1,
                CountryId = 1,
                Name1 = "USA",
                Name2 = "CAN",
                CreatedDate = DateTime.Now


            },
            new CountryBorder
            {
                Id = 2,
                CountryId = 2,
                Name1 = "USA",
                Name2 = "MEX",
                CreatedDate = DateTime.Now


            },
             new CountryBorder
             {
                 Id = 3,
                 CountryId = 3,
                 Name1 = "USA",
                 Name2 = "MEX",
                 Name3 = "BLZ",
                 CreatedDate = DateTime.Now


             },
               new CountryBorder
               {
                   Id = 4,
                   CountryId = 4,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 5,
                   CountryId = 5,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   Name4 = "SLV",
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 6,
                   CountryId = 6,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   Name4 = "HND",
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 7,
                   CountryId = 7,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   Name4 = "HND",
                   Name5 = "NIC",
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 8,
                   CountryId = 8,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   Name4 = "HND",
                   Name5 = "NIC",
                   Name6 = "CRI",
                   CreatedDate = DateTime.Now


               },
               new CountryBorder
               {
                   Id = 9,
                   CountryId = 9,
                   Name1 = "USA",
                   Name2 = "MEX",
                   Name3 = "GTM",
                   Name4 = "HND",
                   Name5 = "NIC",
                   Name6 = "CRI",
                   Name7 = "PAN",
                   CreatedDate = DateTime.Now


               }







               );

        }
    }
}
