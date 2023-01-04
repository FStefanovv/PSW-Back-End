﻿// <auto-generated />
using System;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    partial class IntegrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("IntegrationLibery.News.Message", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Timestamp");

                    b.ToTable("NewsTable");

                    b.HasData(
                        new
                        {
                            Timestamp = new DateTime(2023, 1, 4, 13, 43, 22, 881, DateTimeKind.Local).AddTicks(8630),
                            Id = new Guid("9343f870-5c5f-4556-9a89-0f30adcd9c4a"),
                            Text = "doniraj krv"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Advertisements.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "ad1"
                        },
                        new
                        {
                            Id = 2,
                            Ad = "ad2"
                        },
                        new
                        {
                            Id = 3,
                            Ad = "ad3"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBank.BloodBank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apikey")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BloodBankTable");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Apikey = "efwfe",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "edhb",
                            Username = "101A"
                        },
                        new
                        {
                            Id = new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                            Apikey = "dqad",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "fewsfd",
                            Username = "101A"
                        },
                        new
                        {
                            Id = new Guid("a60460fe-0d33-478d-93b3-45d424079e66"),
                            Apikey = "ads",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "fcsde",
                            Username = "101A"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Report.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ConfigurationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastReportGeneration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Period")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ReportTable");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            ConfigurationDate = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastReportGeneration = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Period = 0
                        },
                        new
                        {
                            Id = new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                            ConfigurationDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastReportGeneration = new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Period = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
