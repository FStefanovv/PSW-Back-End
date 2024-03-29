﻿using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    [Table("VacationRequests")]
    public class VacationRequest
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public bool Urgency { get; set; }
        public int DoctorId { get; set; }
        [JsonIgnore]
        public virtual Doctor.Doctor Doctor { get; set; }
        public string RejectionReason { get; set; }
        public VacationRequestStatus Status { get; set; }

        public VacationRequest()
        {
        }

        public VacationRequest(int id, DateTime start, DateTime end, string description,bool urgency, int doctorId)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.Description = description;
            this.Urgency = urgency;
            this.DoctorId = doctorId;
            this.Status = VacationRequestStatus.WaitingForApproval;
            this.RejectionReason = "nista";
        }

        public VacationRequest(int id, DateTime start, DateTime end, string description, bool urgency, int doctorId, string rejectionReason, VacationRequestStatus status) : this(id, start, end, description, urgency, doctorId)
        {
            RejectionReason = rejectionReason;
            Status = status;
        }
    }
}
