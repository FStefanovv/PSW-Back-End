﻿using System;

namespace HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses
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