using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public interface IBloodSubscriptionRepository
    {
        void Cancel(BloodSubscription sub);
        void Create(BloodSubscription sub);
        BloodSubscription GetActive();
        BloodSubscription GetById(int id);
    }
}
