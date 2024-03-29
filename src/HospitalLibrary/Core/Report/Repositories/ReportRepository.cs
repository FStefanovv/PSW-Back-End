﻿using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly HospitalDbContext _context;

        public ReportRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report.Model.Report> GetAll()
        {

            return _context.Reports.ToList();
        }

        public Report.Model.Report GetById(string id)
        {
            return _context.Reports.Find(id);
        }
        
        public void Create(Report.Model.Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void Update(Report.Model.Report report)
        {
            _context.Entry(report).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Report.Model.Report report)
        {
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }

        public int GetDoctorIdByReportId(string reportId)
        {
            Report.Model.Report report = GetById(reportId);
            int doctorId = report.DoctorId;
            return doctorId;
        }
    }
}

