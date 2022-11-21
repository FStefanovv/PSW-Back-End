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
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodConsumptionRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BloodConsumptionRecords");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Due")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BloodRequests");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("HospitalBlood");
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
                });

            modelBuilder.Entity("HospitalLibrary.Core.Feedback.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Anonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<bool>("VisibleToPublic")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Patient.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Allergies")
                        .HasColumnType("text");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PatientName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
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
                });

            modelBuilder.Entity("HospitalLibrary.Core.Vacation.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("Urgency")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("VacationRequests");
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

            modelBuilder.Entity("HospitalLibrary.Core.Vacation.VacationRequest", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Doctor.Doctor", "Doctor")
                        .WithMany("VacationRequests")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("VacationRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
