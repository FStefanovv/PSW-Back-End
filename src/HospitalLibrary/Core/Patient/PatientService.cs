﻿using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Crypto.Tls;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PatientService(IPatientRepository patientRepository,IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public void Create(Patient patient)
        {
            _patientRepository.Create(patient);
        }

        public void Register(Patient patient)
        {
            patient.Active = false;
            _patientRepository.Create(patient);
        }
        public void Activate(Patient patient)
        {
            patient.Active = true;
            _patientRepository.Update(patient);
        }
        public void Update(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }

        public string GetDoctorWithLeastPatients()
        {
            string minimalId = "nesto";
            int minNumber = 0;
            IEnumerable<Doctor.Doctor> doctors = _doctorRepository.GetAll();
            IEnumerable<Patient> patients = _patientRepository.GetAll();

            foreach(Doctor.Doctor doctor in doctors)
            {
                int personalMinimal = 0;
                foreach(Patient patient in patients)
                {
                    if (patient.DoctorID.Equals(doctor.Id))
                    {
                        personalMinimal++;
                    }
                }
                if(personalMinimal <= minNumber)
                {
                    minNumber = personalMinimal;
                    minimalId = doctor.Id;
                }

            }

            return minimalId;
        }

        public List<string> GetDoctorsWithMaxTwoMorePatients()
        {
            return null;

        }
        public Patient CheckCreditentials(string username, string password)
        {
            foreach(Patient p in GetAll())
            {
                if (p.Email == username)
                    if (p.Password == password)
                        return p;
                    else return null;
            }
            return null;
        }
    }
}
