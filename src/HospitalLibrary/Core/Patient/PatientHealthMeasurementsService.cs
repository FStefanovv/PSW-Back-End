﻿using HospitalLibrary.Core.Patient.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class PatientHealthMeasurementsService : IPatientHealthMeasurementsService
    {
        private readonly IPatientHealthMeasurementsRepository _repository;

        public PatientHealthMeasurementsService(IPatientHealthMeasurementsRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<PatientHealthMeasurements> GetAll()
        {
            return _repository.GetAll();
        }
        public PatientHealthMeasurements GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Create(SubmitPatientHealthMeasurementsDTO dto)
        {
            if(int.TryParse(dto.PatientId, out int patientId) && 
               float.TryParse(dto.Weight, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float weight) &&
               int.TryParse(dto.BloodPressureUpper, out int bloodPressureUpper) &&
               int.TryParse(dto.BloodPressureLower, out int bloodPressureLower) &&
               int.TryParse(dto.Heartbeat, out int heartbeat) &&
               float.TryParse(dto.Temperature, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float temperature) &&
               float.TryParse(dto.BloodSugarLevel, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float bloodSugarLevel))
            {
                var phm = new PatientHealthMeasurements(patientId, weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
                _repository.Create(phm);
            }
            else
            {
                throw new ArgumentException("Inputs must be numbers.");
            }
        }
        public void Update(PatientHealthMeasurements phm)
        {
            _repository.Update(phm);
        }
        public void Delete(PatientHealthMeasurements phm)
        {
            _repository.Delete(phm);
        }
        //ozbiljna kobasica od koda
        public IEnumerable<ReturnMeasurementsDTO> GetPatientHealthMeasurements(GetPatientHealthMeasurementsDTO dto)
        {

            if(!(int.TryParse(dto.Month, out int month) && int.TryParse(dto.PatientId, out int patientId)))
            {
                throw new ArgumentException("PatientId and/or month must be positive integers");
            }
            else if(month <= 0 || month > 12)
            {
                throw new ArgumentException("Month must be an integer between 1 and 12");
            }

            var allPatientsHM =  _repository.GetAll().Where(phm => phm.MeasurementTime.Month == month &&
                                                     phm.MeasurementTime.Year == DateTime.Now.Year &&
                                                     phm.PatientId == patientId).ToList();

            List<ReturnMeasurementsDTO> retList = new();
            List<DateTime> checkedDates = new();
            float avgWeight = 0;
            float avgBloodPressureUpper = 0;
            float avgBloodPressureLower = 0;
            float avgHeartbeat = 0;
            float avgTemperature = 0;
            float avgBloodSugarLevel = 0;
            int counter = 0;

            foreach(PatientHealthMeasurements phm in allPatientsHM)
            {
                var check = phm.MeasurementTime;
                if (checkedDates.Contains(check))
                {
                    continue;
                }
                else
                {
                    checkedDates.Add(check);
                }
                
                foreach(PatientHealthMeasurements it in allPatientsHM)
                {
                    if(it.MeasurementTime == check)
                    {
                        avgWeight += it.HealthMeasurements.Weight;
                        avgBloodPressureUpper += it.HealthMeasurements.BloodPressureUpper;
                        avgBloodPressureLower += it.HealthMeasurements.BloodPressureLower;
                        avgHeartbeat += it.HealthMeasurements.Heartbeat;
                        avgTemperature += it.HealthMeasurements.Temperature;
                        avgBloodSugarLevel += it.HealthMeasurements.BloodSugarLevel;
                        counter += 1;
                    }
                }
                avgWeight /= counter;
                avgBloodPressureUpper /= counter;
                avgBloodPressureLower /= counter;
                avgHeartbeat /= counter;
                avgTemperature /= counter;
                avgBloodSugarLevel /= counter;
                int bpu = (int)Math.Round(avgBloodPressureUpper);
                int bpl = (int)Math.Round(avgBloodPressureLower);
                int hb = (int)Math.Round(avgHeartbeat);
                var add = new ReturnMeasurementsDTO(new PatientHealthMeasurements(phm.PatientId, new DateTime(check.Year, check.Month, check.Day), avgWeight, bpu, bpl, hb, avgTemperature, avgBloodSugarLevel));
                retList.Add(add);
                counter = 0;
                avgWeight = 0;
                avgBloodPressureUpper = 0;
                avgBloodPressureLower = 0;
                avgHeartbeat = 0;
                avgTemperature = 0;
                avgBloodSugarLevel = 0;
            }
            return retList;
        }
    }
}
