﻿using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class BackButtonClicked : DomainEvent
    {

        public BackButtonClicked() { }

        public BackButtonClicked(string aggregateId, int fromStep) : base(aggregateId)
        {
            FromStep = fromStep;
            ClickedAt = DateTime.Now;
        }

        public int FromStep { get; private set; }
        public DateTime ClickedAt { get; private set; }
    }
}
