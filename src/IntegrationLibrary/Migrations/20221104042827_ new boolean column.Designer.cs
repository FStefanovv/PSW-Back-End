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
    [Migration("20221104042827_ new boolean column")]
    partial class newbooleancolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                            Id = new Guid("220c2ea9-54fc-47ad-b231-f6efad8b020f"),
                            Apikey = "efwfe",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "edhb",
                            Username = "101A"
                        },
                        new
                        {
                            Id = new Guid("c85daacb-b094-4181-8311-2b9ddc865c85"),
                            Apikey = "dqad",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "fewsfd",
                            Username = "101A"
                        },
                        new
                        {
                            Id = new Guid("d59911e4-5bbc-4054-a55e-cc6c05c789e7"),
                            Apikey = "ads",
                            Email = "andykesic123@gmail.com",
                            IsConfirmed = true,
                            Password = "fcsde",
                            Username = "101A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
