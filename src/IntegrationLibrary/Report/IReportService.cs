using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Report
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report GetById(Guid id);
        void Create(Report report);
        void Update(Report report);
    }
}