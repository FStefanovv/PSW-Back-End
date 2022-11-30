﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    [Keyless]
    public class Drug
    {
        public string Name;
        public string CompanyName;
    }
}
