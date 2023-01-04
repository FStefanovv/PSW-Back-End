﻿using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class Report : EventSourcedAggregate
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentId { get; set; }
        public string ReportDescription { get; set; }
        public ICollection<Symptom> Symptoms { get; set; }
        public DateTime DayAndTimeOfMaking { get; set; }
        public ICollection<Drug> Drugs { get; set; }

        public int InitialVersion { get; private set; }
        public int NumberOfNextClicks { get; private set; }
        public int NumberOfBackClicks { get; private set; }


        public Report()
        {
        }


        public Report(ReportSnapshot snapshot)
        {
            Version = snapshot.Version;
            InitialVersion = snapshot.Version; 
        }

        public Report(string id, string patientId, string doctorId, string reportDescription, ICollection<Symptom> symptoms, DateTime dayAndTimeOfMaking, ICollection<Drug> drugs)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            ReportDescription = reportDescription;
            Symptoms = symptoms;
            DayAndTimeOfMaking = dayAndTimeOfMaking;
            Drugs = drugs;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version++;
        }

        public void ClickedOnNextButton()
        {

            Causes(new NextButtonClicked(Id, NumberOfNextClicks));
        }

        public void ClickedOnBackButton()
        {

            Causes(new BackButtonClicked(Id, NumberOfBackClicks));
        }



        public void When(NextButtonClicked nextClicked)
        {
            NumberOfNextClicks += 1;
        }

        public void When(BackButtonClicked backClicked)
        {
            NumberOfBackClicks += 1;
        }




    }
}