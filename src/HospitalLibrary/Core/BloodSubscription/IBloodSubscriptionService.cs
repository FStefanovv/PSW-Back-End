using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public interface IBloodSubscriptionService
    {
        BloodSubscription GetActive();
        BloodSupplies GetSupplies();

        void CancelSubscription(BloodSubscription subscription);

        void CreateSubscription(BloodSubscription subscription);

        void RecieveSupplies();
    }
}
