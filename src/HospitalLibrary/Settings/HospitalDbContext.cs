using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Patient;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<BloodSupply> HospitalBlood { get; set; }

        public DbSet<BloodConsumptionRecord> BloodConsumptionRecords { get; set; }

        public DbSet<BloodRequest> BloodRequests { get; set; }

        public DbSet<VacationRequest> VacationRequests { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<VacationRequest>().HasData(
            //    new VacationRequest(1, new DateTime(2023,1,1), new DateTime(2023, 1, 14), "holidays", false, "DOC1"),
            //    new VacationRequest(2, new DateTime(2023, 1, 1), new DateTime(2023, 1, 14), "holidays", false, "DOC2"),
            //    new VacationRequest(3, new DateTime(2023, 1, 1), new DateTime(2023, 1, 14), "holidays", false, "DOC3")
            //     );
            //base.OnModelCreating(modelBuilder);
        }

    }
}