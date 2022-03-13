﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayer.Core.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CAN"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MEX"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "BLZ"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "GTM"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "SLV"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "HND"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "NIC"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CRI"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "PAN"
                        });
                });

            modelBuilder.Entity("NLayer.Core.CountryBorder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name2")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name3")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name4")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name5")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name6")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name7")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name8")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name9")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CountryBorders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6458),
                            Name1 = "USA",
                            Name2 = "CAN"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6524),
                            Name1 = "USA",
                            Name2 = "MEX"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6533),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "BLZ"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 4,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6537),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 5,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6546),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM",
                            Name4 = "SLV"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 6,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6555),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM",
                            Name4 = "HND"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 7,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6563),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM",
                            Name4 = "HND",
                            Name5 = "NIC"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 8,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6573),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM",
                            Name4 = "HND",
                            Name5 = "NIC",
                            Name6 = "CRI"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 9,
                            CreatedDate = new DateTime(2022, 3, 11, 23, 50, 5, 455, DateTimeKind.Local).AddTicks(6582),
                            Name1 = "USA",
                            Name2 = "MEX",
                            Name3 = "GTM",
                            Name4 = "HND",
                            Name5 = "NIC",
                            Name6 = "CRI",
                            Name7 = "PAN"
                        });
                });

            modelBuilder.Entity("NLayer.Core.CountryBorder", b =>
                {
                    b.HasOne("NLayer.Core.Country", "Country")
                        .WithMany("CountryBorders")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("NLayer.Core.Country", b =>
                {
                    b.Navigation("CountryBorders");
                });
#pragma warning restore 612, 618
        }
    }
}