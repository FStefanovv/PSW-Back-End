﻿using HospitalLibrary.Core.Consiliums.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using HospitalLibrary.Core;
using HospitalLibrary.Core.Doctor;
using Moq;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Appointment;
/*
namespace HospitalLibraryTestProject
{
    public class ConsiliumCreationTests
    {
        [Fact]
        public void Has_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            ConsiliumService consiliumService = new ConsiliumService(CreateConsiliumRepository(), doctorService); 
            ConsiliumRequestDTO consiliumAppointmentInfo = new ConsiliumRequestDTO("We have a complex case and need to discuss it with colleagues", "14/12/2022", "18/12/2022", 45, "DOC1,DOC2", "");

            List<PotentialAppointmentsDTO> potentialConsiliumAppointments = consiliumService.GetPotentialAppointmentTimesForDoctors(consiliumAppointmentInfo);

            Assert.NotEmpty(potentialConsiliumAppointments);
        }

        [Fact]
        public void Has_no_available_appointments()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepositoryUnavailable());
            ConsiliumService consiliumService = new ConsiliumService(CreateConsiliumRepository(), doctorService);
            ConsiliumRequestDTO consiliumAppointmentInfo = new ConsiliumRequestDTO("We have a complex case and need to discuss it with colleagues", "15/12/2022", "16/12/2022", 45, "DOC1,DOC2", "");

            List<PotentialAppointmentsDTO> potentialConsiliumAppointments = consiliumService.GetPotentialAppointmentTimesForDoctors(consiliumAppointmentInfo);

            Assert.Empty(potentialConsiliumAppointments);
        }
        
        [Fact]
        public void Doctors_available()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 45, 0), new DateTime(2022, 12, 15, 15, 55, 0));
           // List<Doctor> neededDoctors = doctorService.GetByIds(DOC1,DOC2);

            bool available = doctorService.AreAvailableForConsilium(neededDoctors, consiliumInterval);

            Assert.True(available);
        }

        [Fact]
        public void Doctors_not_available()
        {
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 14, 50, 0), new DateTime(2022, 12, 15, 15, 30, 0));
            List<Doctor> neededDoctors = doctorService.GetByIds("DOC1,DOC2");


            bool available = doctorService.AreAvailableForConsilium(neededDoctors, consiliumInterval);

            Assert.False(available);
        }

        [Fact]
        public void Has_available_for_specialty()
        {
           
            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 45, 0), new DateTime(2022, 12, 15, 15, 55, 0));


            List<Doctor> doctors = doctorService.GetAvailableBySpecialty(0, consiliumInterval);

            Assert.NotEmpty(doctors);
        }

        [Fact]
        public void Doesnt_have_available_for_specialty()
        {

            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 30, 0), new DateTime(2022, 12, 15, 15, 55, 0));


            List<Doctor> doctors = doctorService.GetAvailableBySpecialty(0, consiliumInterval);

            Assert.Empty(doctors);
        }

        [Fact]
        public void Has_available_for_each_specialty()
        {

            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 45, 0), new DateTime(2022, 12, 15, 15, 55, 0));
            string specialties = "0";

            List<Doctor> availableByEachSpecialty = doctorService.AvailableByEachSpecialty(specialties, consiliumInterval);

            Assert.NotNull(availableByEachSpecialty);
        }

        [Fact]
        public void Doesnt_have_available_for_each_specialty()
        {

            DoctorService doctorService = new DoctorService(CreateDoctorRepository());
            DateTimeRange consiliumInterval = new DateTimeRange(new DateTime(2022, 12, 15, 15, 30, 0), new DateTime(2022, 12, 15, 15, 55, 0));
            string specialties = "0";

            List<Doctor> availableByEachSpecialty = doctorService.AvailableByEachSpecialty(specialties, consiliumInterval);

            Assert.Null(availableByEachSpecialty);
        }




        private IDoctorRepository CreateDoctorRepository()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            List<Appointment> doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC1", "PAT0", new DateTime(2022, 12, 15, 15, 20, 0), 0));
            
            Doctor doctor1 = new Doctor("DOC1", "Doktor", "Doktoric", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments, 1);
            doctors.Add(doctor1);

            List<Doctor> bySpec0 = new List<Doctor>();
            bySpec0.Add(doctor1);


            doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP1", 2, "PAT0", new DateTime(2022, 12, 15, 16, 0, 0), 0));
            
            
            Doctor doctor2 = new Doctor(2, "Doktorka", "Doktoricka", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments, 1);
            doctors.Add(doctor2);

            List<Doctor> bySpec1 = new List<Doctor>();
            bySpec1.Add(doctor2);

            stubRepo.Setup(m => m.GetAll()).Returns(doctors);
            stubRepo.Setup(m => m.GetByIds("DOC1,DOC2")).Returns(doctors);
            stubRepo.Setup(m => m.GetBySpecialty(0)).Returns(bySpec0);
            stubRepo.Setup(m => m.GetBySpecialty(1)).Returns(bySpec1);


            return stubRepo.Object;
        }

        private IDoctorRepository CreateDoctorRepositoryUnavailable()
        {
            var stubRepo = new Mock<IDoctorRepository>();
            var doctors = new List<Doctor>();

            List<Appointment> doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP0", "DOC1", "PAT0", new DateTime(2022, 12, 15, 15, 20, 0), 0));

            Doctor doctor1 = new Doctor("DOC1", "Doktor", "Doktoric", "nekimail@gmail.com", 0, new Room(), 8, 16, doctorAppointments, 1);
            doctors.Add(doctor1);

            List<Doctor> bySpec0 = new List<Doctor>();
            bySpec0.Add(doctor1);


            doctorAppointments = new List<Appointment>();
            doctorAppointments.Add(new Appointment("APP1", "DOC2", "PAT0", new DateTime(2022, 12, 15, 16, 0, 0), 0));


            Doctor doctor2 = new Doctor("DOC2", "Doktorka", "Doktoricka", "nekimail@gmail.com", 0, new Room(), 17, 22, doctorAppointments, 1);
            doctors.Add(doctor2);

            List<Doctor> bySpec1 = new List<Doctor>();
            bySpec1.Add(doctor2);

            stubRepo.Setup(m => m.GetAll()).Returns(doctors);
            stubRepo.Setup(m => m.GetByIds("DOC1,DOC2")).Returns(doctors);
            stubRepo.Setup(m => m.GetBySpecialty(0)).Returns(bySpec0);
            stubRepo.Setup(m => m.GetBySpecialty(1)).Returns(bySpec1);


            return stubRepo.Object;
        }





        private IConsiliumRepository CreateConsiliumRepository()
        {
            var stubRepo = new Mock<IConsiliumRepository>();

            return stubRepo.Object;
        }
    }
}*/
