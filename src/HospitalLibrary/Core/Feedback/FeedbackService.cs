﻿using HospitalLibrary.Core.Patient;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IPatientService _patientService;

        public FeedbackService(IFeedbackRepository feedbackRepository,IPatientService patientService)
        {
           _feedbackRepository= feedbackRepository;
            _patientService= patientService;

        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public void Create(Feedback feedback)
        {
            feedback.Date = System.DateTime.Today;
            feedback.Approved = false;
            Patient.Patient patient=_patientService.GetById(feedback.PatientId);
            feedback.PatientName=patient.Name; feedback.PatientSurname=patient.Surname;
            _feedbackRepository.Create(feedback);
        }

        public void Update(Feedback feedback)
        {
            _feedbackRepository.Update(feedback);
        }

        public void Delete(Feedback feedback)
        {
            _feedbackRepository.Delete(feedback);
        }
        public void ChangeApproval(int feedbackId)
        {
            Feedback feedback = GetById(feedbackId);
            if (feedback.Approved) feedback.Approved = false;
            else feedback.Approved = true;
            _feedbackRepository.Update(feedback);
        }
        public void ChangeVisibility(int feedbackId)
        {
            Feedback feedback = GetById(feedbackId);
            if (feedback.VisibleToPublic) feedback.VisibleToPublic = false;
            else feedback.VisibleToPublic = true;
            _feedbackRepository.Update(feedback);
        }
    }
}

