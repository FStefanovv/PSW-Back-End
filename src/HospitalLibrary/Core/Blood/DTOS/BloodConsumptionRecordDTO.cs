﻿using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood.DTOS
{
    public class BloodConsumptionRecordDTO
    {
        private IBloodService bloodService;

        public BloodConsumptionRecordDTO(){}

        public BloodConsumptionRecordDTO(IBloodService bloodService)
        {
            this.bloodService = bloodService;
        }

        public double amount { get; set; }
        public string type { get; set; }
        public string reason { get; set; }
    }
}
