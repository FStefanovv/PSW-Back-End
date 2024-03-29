﻿using HospitalLibrary.Core.Infrastructure;
using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public interface IReportApplicationService
    {
        IEnumerable<Report.Model.Report> GetAll();
        Report.Model.Report GetById(string id);
        void Create(ReportToCreateDTO report);

        void Update(Report.Model.Report report);
        void Delete(Report.Model.Report report);

        bool IsSymptomExist(ICollection<Symptom> symptoms, string id);

        ReportToShowDTO GetReportToShow(string id);

        ICollection<Drug> GetDrugFromReport(string reportId);

        DrugPrescriptionToShowDTO GetDrugToShow(string id);
        string InstantiateReport();
        DomainEvent HandleClick(string id, int eventCode);
        void SetReportFields(string id, ReportToCreateDTO dto);
        List<SearchResultReportDTO> GetSearchMatches(string[] searchWords);
    }
}
