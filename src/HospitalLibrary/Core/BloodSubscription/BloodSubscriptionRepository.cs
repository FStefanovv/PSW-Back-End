using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public class BloodSubscriptionRepository : IBloodSubscriptionRepository
    {
        private HospitalDbContext _context;
        
        public BloodSubscriptionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(BloodSubscription sub)
        {
            _context.Add(sub);
            _context.SaveChanges();
        }

        public BloodSubscription GetActive()
        {
            return _context.BloodSubscriptions.FirstOrDefault(s => s.IsActive == true);
        }

        public BloodSubscription GetById(int id)
        {
            return _context.BloodSubscriptions.Find(id);
        }

        public void Cancel(BloodSubscription subscription)
        {
            _context.Entry(subscription).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
