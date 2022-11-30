﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public interface IDrugRepository
    {
        IEnumerable<Drug> GetAll();
      

    }
}