﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Infrastructure
{
    public abstract class DomainEvent
    {
        public DomainEvent(Guid aggregateId)
        {
            Id = aggregateId;
        }

        public Guid Id { get; private set; }
    }
}