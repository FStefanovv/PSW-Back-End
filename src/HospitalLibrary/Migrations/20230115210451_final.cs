﻿using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Report.Model;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:allergy", "pollen,dust,feathers,cats,dogs,garlic,peanuts,milk,rice,celery,gluten,crustaceans,eggs,soya,fish,nuts,insects,latex,shellfish,tetracycline,penicillin,anaesthetics,dilantin,tegretol,cephalosporins,sulphonamides")
                .Annotation("Npgsql:Enum:appointment_status", "scheduled,finished,cancelled")
                .Annotation("Npgsql:Enum:blood_type", "a,b,ab,o")
                .Annotation("Npgsql:Enum:equipment_type", "bed,bandages,medicine")
                .Annotation("Npgsql:Enum:gender", "male,female")
                .Annotation("Npgsql:Enum:specialty", "cardiologist,anesthesiologist,neurosurgeon,general")
                .Annotation("Npgsql:Enum:vacation_request_status", "waiting_for_approval,cancelled,accepted,disapproved");

            migrationBuilder.CreateTable(
                name: "BloodConsumptionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodConsumptionRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Blood_Type = table.Column<BloodType>(type: "blood_type", nullable: true),
                    Blood_Amount = table.Column<double>(type: "double precision", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    Due = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consiliums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Specialties = table.Column<string>(type: "text", nullable: true),
                    DoctorIds = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Finished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consiliums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugPrescriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ReportId = table.Column<string>(type: "text", nullable: true),
                    Drugs = table.Column<ICollection<Drug>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugPrescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugsList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    EventInstance = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    PatientSurname = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    VisibleToPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Anonymous = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBlood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    SourceBank = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBlood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InpatientTreatmentRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DoctorID = table.Column<int>(type: "integer", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    RoomID = table.Column<string>(type: "text", nullable: true),
                    BedID = table.Column<string>(type: "text", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Therapy = table.Column<string>(type: "text", nullable: true),
                    AdmissionReason = table.Column<string>(type: "text", nullable: true),
                    DischargeReason = table.Column<string>(type: "text", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatmentRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientHealthMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    MeasurementTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHealthMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    AddressJson = table.Column<string>(type: "jsonb", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<Gender>(type: "gender", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<BloodType>(type: "blood_type", nullable: false),
                    Allergies = table.Column<List<Allergy>>(type: "allergy[]", nullable: true),
                    DoctorID = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Jmbg = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentId = table.Column<string>(type: "text", nullable: true),
                    ReportDescription = table.Column<string>(type: "text", nullable: true),
                    DayAndTimeOfMaking = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialVersion = table.Column<int>(type: "integer", nullable: false),
                    CurrentStep = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdByRole = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthMeasurements",
                columns: table => new
                {
                    PatientHealthMeasurementsId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    BloodPressureUpper = table.Column<int>(type: "integer", nullable: false),
                    BloodPressureLower = table.Column<int>(type: "integer", nullable: false),
                    Heartbeat = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    BloodSugarLevel = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthMeasurements", x => x.PatientHealthMeasurementsId);
                    table.ForeignKey(
                        name: "FK_HealthMeasurements_PatientHealthMeasurements_PatientHealthM~",
                        column: x => x.PatientHealthMeasurementsId,
                        principalTable: "PatientHealthMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => new { x.ReportId, x.Id });
                    table.ForeignKey(
                        name: "FK_Drugs_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportCreationEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<string>(type: "text", nullable: true),
                    event_type = table.Column<string>(type: "text", nullable: false),
                    FromStep = table.Column<int>(type: "integer", nullable: true),
                    ClickedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    NextButtonClicked_FromStep = table.Column<int>(type: "integer", nullable: true),
                    NextButtonClicked_ClickedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCreationEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportCreationEvents_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => new { x.ReportId, x.Id });
                    table.ForeignKey(
                        name: "FK_Symptoms_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Specialty = table.Column<Specialty>(type: "specialty", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    StartWorkTime = table.Column<int>(type: "integer", nullable: false),
                    EndWorkTime = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<EquipmentType>(type: "equipment_type", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<AppointmentStatus>(type: "appointment_status", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsiliumAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    ConsiliumId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsiliumAppointments_Consiliums_ConsiliumId",
                        column: x => x.ConsiliumId,
                        principalTable: "Consiliums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumAppointments_Doctors_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Urgency = table.Column<bool>(type: "boolean", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    RejectionReason = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<VacationRequestStatus>(type: "vacation_request_status", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DrugsList",
                columns: new[] { "Id", "CompanyName", "Name" },
                values: new object[,]
                {
                    { "fervex", "Bayer", "Fervex" },
                    { "gentamicin", "Galenika", "Gentamicin" },
                    { "baktrim", "Hemofarm", "Baktrim" },
                    { "rivotril", "Galenika", "Rivotril" },
                    { "strepsils", "Bayer", "Strepsils" },
                    { "prospan", "Bayer", "Prospan" },
                    { "bromazepam", "Hemofarm", "Bromazepam" },
                    { "bensedin", "Galenika", "Bensedin" },
                    { "panadol", "Hemofarm", "Panadol" },
                    { "brufen", "Galenika", "Brufen" },
                    { "aspirin", "Galenika", "Aspirin" }
                });

            migrationBuilder.InsertData(
                table: "HospitalBlood",
                columns: new[] { "Id", "Amount", "SourceBank", "Type" },
                values: new object[,]
                {
                    { 4, 10.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.O },
                    { 8, 10.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.B },
                    { 6, 40.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), BloodType.B },
                    { 2, 30.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.B },
                    { 9, 34.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.AB },
                    { 3, 15.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.AB },
                    { 7, 24.0, new Guid("a60460fe-0d33-478d-93b3-45d424079e66"), BloodType.A },
                    { 5, 23.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), BloodType.A },
                    { 1, 54.0, new Guid("2d4894b6-02e4-4288-a3d3-089489563190"), BloodType.A },
                    { 10, 40.0, new Guid("55510651-d36e-444d-95fb-871e0902cd7e"), BloodType.O }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "Number" },
                values: new object[,]
                {
                    { 3, 1, "1C" },
                    { 4, 2, "2A" },
                    { 5, 2, "2B" },
                    { 6, 2, "2C" },
                    { 999, 4, "Consilium Hall" },
                    { 8, 3, "3B" },
                    { 9, 3, "3F" },
                    { 2, 1, "1B" },
                    { 7, 3, "3A" },
                    { 1, 1, "1A" }
                });

            migrationBuilder.InsertData(
                table: "SymptomList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "Fatigue", "Fatigue" },
                    { "Vomiting", "Vomiting" },
                    { "Chronic pain", "Chronic pain" },
                    { "Short breath", "Short breath" },
                    { "Fever", "Fever" },
                    { "Vertigo", "Vertigo" },
                    { "High blood pressure", "High blood pressure" },
                    { "Headache", "Headache" },
                    { "Cough", "Cough" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Email", "IdByRole", "Name", "Password", "Role", "Surname", "Token" },
                values: new object[,]
                {
                    { 8, true, "milica.jezdic@gmail.com", 7, "Milica", "ADCyG1fHX04K+wTwzJDPmb78k1YWMfTQqgeDZKorMbE46o0+zXEc2NF1SHjkEAiaWw==", "DOCTOR", "Jezdic", null },
                    { 7, true, "katarina.radic@gmail.com", 6, "Katarina", "APxtdhzFubuhYnLITUwNYcwwt0ySvkTJ7C5qayocG3x5L9p3MbN3P0f27EYOCCInvw==", "DOCTOR", "Radic", null },
                    { 6, true, "bojana.jelic@gmail.com", 5, "Bojana", "AEHe2m50J9F9RMJHmvuxZAQ9VFzCV7ebMjJFG/NND8GQM/C3tBut/fl1mhz0veof5Q==", "DOCTOR", "Jelic", null },
                    { 5, true, "stefan.simic@gmail.com", 4, "Stefan", "AJbKG1PpVed0VCFu358yyNfXy8RsWk6sB55ejeXQaFOV3nQxSImn6qsLGS6N5oQfqg==", "DOCTOR", "Simic", null },
                    { 1, true, "manageremail@gmail.com", 1, "Milica", "AJMjUEYXE/EtKJlD2NfDblnM15ik0Wo547IgBuUFWyJtWRhj5PSBO/ttok4DT679oA==", "MANAGER", "Peric", null },
                    { 3, true, "gorana.miljkovic@gmail.com", 2, "Gorana", "AGEU6JzOVaDY+DYUWWiWOKbrpIHMwuW2fyh6CJai+D159dhE0IRmWjM3oQVlAS3hlw==", "DOCTOR", "Miljkovic", null },
                    { 2, true, "doctorfilip@hotmail.com", 1, "Filip", "AKTyL6i1roIESl/br0aDrci1H15gFj0Wwede2GYJi0csDSUhrydNioQui0K3gfkJcA==", "DOCTOR", "Marinkovic", null },
                    { 9, true, "zoran.katic@gmail.com", 8, "Zoran", "AA+E3CZi5TQ3+ciHGpGi7NFiE2GZDawBlSyBOK4IZd28ZB6oZWWOqY+gxY93xmI8kw==", "DOCTOR", "Katic", null },
                    { 4, true, "petar.dobrosavljevic@gmail.com", 3, "Petar", "AAQWjfiC3pkhMnwzKmJjhwytFO73mFNYklxj6/hTSj0aS3j3KxTe7TsmqVmXSy0fnQ==", "DOCTOR", "Dobrosavljevic", null },
                    { 10, true, "bojan.stanic@gmail.com", 9, "Bojan", "AL4E2lLskVtWAOnmsPLxHDP8hxJVqshvbL2F6uKhd51bCB/n07IYj6uabGAKTtYZlg==", "DOCTOR", "Stanic", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Email", "EndWorkTime", "Name", "RoomId", "Specialty", "StartWorkTime", "Surname" },
                values: new object[,]
                {
                    { 1, 32, "doctorfilip@hotmail.com", 13, "Filip", 1, Specialty.Cardiologist, 8, "Marinkovic" },
                    { 7, 27, "milica.jezdic@gmail.com", 13, "Milica", 7, Specialty.General, 7, "Jezdic" },
                    { 6, 34, "katarina.radic@gmail.com", 20, "Katarina", 6, Specialty.Neurosurgeon, 14, "Radic" },
                    { 5, 51, "bojana.jelic@gmail.com", 16, "Bojana", 5, Specialty.Neurosurgeon, 8, "Jelic" },
                    { 4, 27, "stefan.simic@gmail.com", 13, "Stefan", 4, Specialty.Anesthesiologist, 8, "Simic" },
                    { 8, 27, "zoran.katic@gmail.com", 13, "Zoran", 8, Specialty.General, 8, "Katic" },
                    { 3, 40, "petar.dobrosavljevic@gmail.com", 20, "Petar", 3, Specialty.Cardiologist, 13, "Dobrosavljevic" },
                    { 9, 35, "bojan.stanic@gmail.com", 19, "Bojan", 9, Specialty.General, 11, "Stanic" },
                    { 2, 29, "gorana.miljkovic@gmail.com", 20, "Gorana", 2, Specialty.Anesthesiologist, 13, "Miljkovic" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Quantity", "RoomId", "Type" },
                values: new object[,]
                {
                    { "4", 1, 3, EquipmentType.BED },
                    { "6", 1, 2, EquipmentType.BED },
                    { "2", 1, 2, EquipmentType.BED },
                    { "10", 1, 5, EquipmentType.BED },
                    { "11", 1, 5, EquipmentType.BED },
                    { "3", 1, 1, EquipmentType.BED },
                    { "8", 1, 6, EquipmentType.BED },
                    { "9", 1, 6, EquipmentType.BED },
                    { "1", 1, 1, EquipmentType.BED },
                    { "7", 1, 2, EquipmentType.BED },
                    { "5", 1, 3, EquipmentType.BED }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumAppointments_ConsiliumId",
                table: "ConsiliumAppointments",
                column: "ConsiliumId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumAppointments_DoctorId1",
                table: "ConsiliumAppointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCreationEvents_ReportId",
                table: "ReportCreationEvents",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_DoctorId",
                table: "VacationRequests",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodConsumptionRecords");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "ConsiliumAppointments");

            migrationBuilder.DropTable(
                name: "DrugPrescriptions");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "DrugsList");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "EventStreams");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "HealthMeasurements");

            migrationBuilder.DropTable(
                name: "HospitalBlood");

            migrationBuilder.DropTable(
                name: "InpatientTreatmentRecords");

            migrationBuilder.DropTable(
                name: "ReportCreationEvents");

            migrationBuilder.DropTable(
                name: "SymptomList");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Consiliums");

            migrationBuilder.DropTable(
                name: "PatientHealthMeasurements");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
