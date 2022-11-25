﻿// <auto-generated />
using System;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20221124144916_mkj")]
    partial class mkj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Timestamp = new DateTime(2022, 11, 24, 15, 49, 15, 6, DateTimeKind.Local).AddTicks(8932),
                            Id = new Guid("bdf7764b-269f-4559-9ae5-86b6b021d4f7"),
                            Text = "doniraj krv"
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
                            Id = new Guid("a60460fe-0d33-478d-93b3-45d424079e66"),
                            ConfigurationDate = new DateTime(2022, 11, 24, 15, 49, 15, 33, DateTimeKind.Local).AddTicks(2779),
                            LastReportGeneration = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Period = 0
                        },
                        new
                        {
                            Id = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            ConfigurationDate = new DateTime(2022, 11, 24, 15, 49, 15, 34, DateTimeKind.Local).AddTicks(349),
                            LastReportGeneration = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Period = 1
                        },
                        new
                        {
                            Id = new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                            ConfigurationDate = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LastReportGeneration = new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Period = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
