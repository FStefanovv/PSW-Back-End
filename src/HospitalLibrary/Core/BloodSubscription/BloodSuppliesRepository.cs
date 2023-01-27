using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public class BloodSuppliesRepository: IBloodSuppliesRepository
    {
        HospitalDbContext _context;

        public BloodSuppliesRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public BloodSupplies GetById(int id)
        {
            return _context.BloodSupplies.Find(id);
        }

        public void Update(BloodSupplies supplies)
        {
            _context.Entry(supplies).State = EntityState.Modified;

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
