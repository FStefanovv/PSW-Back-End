﻿// <auto-generated />
using System;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HospitalLibrary.Core.Appointment.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("RoomId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = "APP1",
                            DoctorId = "DOC1",
                            Duration = 0,
                            PatientId = "PAT1",
                            RoomId = 1,
                            Start = new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        },
                        new
                        {
                            Id = "APP2",
                            DoctorId = "DOC2",
                            Duration = 0,
                            PatientId = "PAT2",
                            RoomId = 2,
                            Start = new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        },
                        new
                        {
                            Id = "APP3",
                            DoctorId = "DOC3",
                            Duration = 0,
                            PatientId = "PAT3",
                            RoomId = 2,
                            Start = new DateTime(2022, 10, 25, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            Status = 0
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("EndWorkTime")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("StartWorkTime")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = "DOC1",
                            Email = "imeprezime024@gmail.com",
                            EndWorkTime = 15,
                            Name = "Ime",
                            RoomId = 1,
                            StartWorkTime = 8,
                            Surname = "Prezime"
                        },
                        new
                        {
                            Id = "DOC2",
                            Email = "peraperic024@gmail.com",
                            EndWorkTime = 15,
                            Name = "Pera",
                            RoomId = 2,
                            StartWorkTime = 8,
                            Surname = "Peric"
                        },
                        new
                        {
                            Id = "DOC3",
                            Email = "djole1312@gmail.com",
                            EndWorkTime = 15,
                            Name = "Djole",
                            RoomId = 3,
                            StartWorkTime = 8,
                            Surname = "Djokic"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Room.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Floor = 1,
                            Number = "101A"
                        },
                        new
                        {
                            Id = 2,
                            Floor = 2,
                            Number = "204"
                        },
                        new
                        {
                            Id = 3,
                            Floor = 3,
                            Number = "305B"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Appointment.Appointment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Doctor.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalLibrary.Core.Room.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Room.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
