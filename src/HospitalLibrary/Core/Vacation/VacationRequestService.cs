﻿using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Vacation.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    public class VacationRequestService
    {
        private readonly IVacationRequestRepository _vacationRequestRepository;



        public VacationRequestService(IVacationRequestRepository vacationRequestRepository)
        {
            _vacationRequestRepository = vacationRequestRepository;
        }

        public IEnumerable<VacationRequest> GetAll()
        {
            return _vacationRequestRepository.GetAll();
        }

        public VacationRequest GetById(int id)
        {
            return _vacationRequestRepository.GetById(id);
        }

        public Boolean CheckIfVacationIsSetInFuture(DateTime dateToCheck)
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dateTimeNow.Year > dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Month > dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Day >= dateToCheck.Day && dateTimeNow.Month >= dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GenerateId()
        {
            List<int> ids = new List<int>();
            IEnumerable<VacationRequest> requests = _vacationRequestRepository.GetAll();
            ids = requests.Select(r => r.Id).ToList();
            if (ids.Count == 0)
                return 0;
            else
                return ids.Max() + 1;
        }

        public void Cancel(int requestId)
        {
            VacationRequest request = _vacationRequestRepository.GetById(requestId);
            request.Status = VacationRequestStatus.Cancelled;
            _vacationRequestRepository.Update(request);
        }

        public void Disapprove(int requestId)
        {
            VacationRequest request = _vacationRequestRepository.GetById(requestId);
            request.Status = VacationRequestStatus.Disapproved;
            _vacationRequestRepository.Update(request);
        }

        public IEnumerable<ViewAllVacationRequestsDTO> GetAllByDoctor(string id)
        {
            IEnumerable<VacationRequest> doctorsVacationRequests = _vacationRequestRepository.GetAllByDoctor(id);
            List<ViewAllVacationRequestsDTO> requestsDTO = new List<ViewAllVacationRequestsDTO>();
            foreach (VacationRequest a in doctorsVacationRequests)
                requestsDTO.Add(VacationRequestAdapter.VacationRequestToDTO(a));

            return requestsDTO;
        }

    }
}