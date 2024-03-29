﻿using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class ConsiliumRepository  : IConsiliumRepository
    {
        private readonly HospitalDbContext _context;

        public ConsiliumRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Consilium> GetAll()
        {
            //UpdateFinishedConsiliums();
            return _context.Consiliums.ToList();
        }

        public Consilium GetById(int id)
        {
            return _context.Consiliums.Find(id);
        }

        public Consilium Create(Consilium consilium)
        {
            try
            {
                _context.Consiliums.Add(consilium);

                _context.SaveChanges();

                Consilium lastAdded = _context.Consiliums.OrderByDescending(cons => cons.Id).FirstOrDefault();

                List<ConsiliumAppointment> appointments = CreateConsiliumAppointments(lastAdded);

                _context.ConsiliumAppointments.AddRange(appointments);

                _context.SaveChanges();
                

                return lastAdded;
            }
            catch (Exception) {
                return null;
            }
           
        }

        public List<ConsiliumAppointment> CreateConsiliumAppointments(Consilium consilium)
        {

            string[] doctorIds = consilium.DoctorIds.Split(',');
            List<ConsiliumAppointment> appointments = new List<ConsiliumAppointment>();
            foreach (string doctorId in doctorIds)
            {
                ConsiliumAppointment appointment = new ConsiliumAppointment(doctorId, consilium.Id);
                appointments.Add(appointment);
            }


            return appointments;
        }

        public void Update(Consilium consilium)
        {
            _context.Entry(consilium).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Consilium consilium)
        {
            _context.Consiliums.Remove(consilium);
            _context.SaveChanges();
        }

        /*
        private void UpdateFinishedConsiliums()
        {
            List<Consilium> consiliums = (List<Consilium>) GetAll();

            DateTime currentTime = DateTime.Now;

            foreach (Consilium consilium in consiliums)
            {
                if (currentTime > consilium.Start.AddMinutes(consilium.Duration))
                {
                    consilium.Finished = true;
                    Update(consilium);
                }
            }
        }*/
    }
}
