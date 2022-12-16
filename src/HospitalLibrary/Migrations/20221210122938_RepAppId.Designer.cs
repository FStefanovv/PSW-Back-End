﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20221210122938_RepAppId")]
    partial class RepAppId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("SourceBank")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BloodConsumptionRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2.0,
                            CreatedAt = new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = "DOC1",
                            Reason = "needed for surgery",
                            SourceBank = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Type = 0
                        });
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

                    b.Property<Guid>("SourceBank")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("HospitalBlood");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Amount = 10.0,
                            SourceBank = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Type = 3
                        },
                        new
                        {
                            Id = 1,
                            Amount = 54.0,
                            SourceBank = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            Amount = 23.0,
                            SourceBank = new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            Amount = 24.0,
                            SourceBank = new Guid("a60460fe-0d33-478d-93b3-45d424079e66"),
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 15.0,
                            SourceBank = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Type = 2
                        },
                        new
                        {
                            Id = 9,
                            Amount = 34.0,
                            SourceBank = new Guid("a60460fe-0d33-478d-93b3-45d424079e66"),
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            Amount = 30.0,
                            SourceBank = new Guid("2d4894b6-02e4-4288-a3d3-089489563190"),
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 40.0,
                            SourceBank = new Guid("55510651-d36e-444d-95fb-871e0902cd7e"),
                            Type = 1
                        },
                        new
                        {
                            Id = 8,
                            Amount = 10.0,
                            SourceBank = new Guid("a60460fe-0d33-478d-93b3-45d424079e66"),
                            Type = 1
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

                    b.Property<string>("PatientName")
                        .HasColumnType("text");

                    b.Property<string>("PatientSurname")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<bool>("VisibleToPublic")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Quantity = 1,
                            RoomId = 1,
                            Type = 0
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.InpatientTreatmentRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AdmissionReason")
                        .HasColumnType("text");

                    b.Property<string>("BedID")
                        .HasColumnType("text");

                    b.Property<DateTime>("DischargeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DischargeReason")
                        .HasColumnType("text");

                    b.Property<string>("DoctorID")
                        .HasColumnType("text");

                    b.Property<string>("PatientID")
                        .HasColumnType("text");

                    b.Property<string>("RoomID")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Therapy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InpatientTreatmentRecords");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AdmissionDate = new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AdmissionReason = "bolesnik",
                            BedID = "1",
                            DischargeDate = new DateTime(22, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DischargeReason = "",
                            DoctorID = "1",
                            PatientID = "1",
                            RoomID = "1",
                            Status = true,
                            Therapy = "nista"
                        });
                });

            modelBuilder.Entity("HospitalLibrary.Core.Patient.Patient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Allergies")
                        .HasColumnType("text[]");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Drug", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.DrugPrescription", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<ICollection<Drug>>("Drugs")
                        .HasColumnType("jsonb");

                    b.Property<string>("ReportId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrugPrescriptions");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppointmentId")
                        .HasColumnType("text");

                    b.Property<DateTime>("DayAndTimeOfMaking")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.Property<string>("ReportDescription")
                        .HasColumnType("text");

                    b.Property<ICollection<Symptom>>("Symptoms")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Symptom", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.SymptomList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SymptomList");

                    b.HasData(
                        new
                        {
                            Id = "Glavobolja",
                            Name = "Glavobolja"
                        },
                        new
                        {
                            Id = "Kijavica",
                            Name = "Kijavica"
                        },
                        new
                        {
                            Id = "Dijareja",
                            Name = "Dijareja"
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
                });

            modelBuilder.Entity("HospitalLibrary.Core.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.Equipment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Room.Room", null)
                        .WithMany("Equipment")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("HospitalLibrary.Core.Room.Room", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
