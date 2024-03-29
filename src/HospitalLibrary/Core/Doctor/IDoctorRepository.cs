﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        //List<Doctor> GetByIds(string doctorIds);
        List<Doctor> GetBySpecialty(int specialty);
    }
}
