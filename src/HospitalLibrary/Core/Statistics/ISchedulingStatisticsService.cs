﻿using HospitalLibrary.Core.ApptSchedulingSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Statistics
{
    public interface ISchedulingStatisticsService
    {
        public List<List<StatisticEntry>> GetStatistics();
        public List<TableEntry> GetTableStats();
    }
}
