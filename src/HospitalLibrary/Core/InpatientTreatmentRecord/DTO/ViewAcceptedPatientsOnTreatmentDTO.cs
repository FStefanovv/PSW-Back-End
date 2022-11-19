﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord.DTO
{
    public class ViewAcceptedPatientsOnTreatmentDTO
    {
        public string patientId { get; set; }
        public string roomId { get; set; }
        public string bedId { get; set; }

        public ViewAcceptedPatientsOnTreatmentDTO() { }
    }
}
