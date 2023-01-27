using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public class BloodSubscription
    {
        public int Id { get; set; }

        public int HospitalId { get; set; }
        public int AmountOfA { get; set; }
        public int AmountOfB { get; set; }
        public int AmountOfAB { get; set; }
        public int AmountOfO { get; set; }
        public int DeliveryDate { get; set; }
        public bool IsActive { get; set; }

        public BloodSubscription() { }

        public BloodSubscription(int id, int hospitalId, int amountOfA, int amountOfB, int amountOfAB, int amountOfO, int deliveryDate, bool isActive)
        {
            Id = id;
            HospitalId = hospitalId;
            AmountOfA = amountOfA;
            AmountOfB = amountOfB;
            AmountOfAB = amountOfAB;
            AmountOfO = amountOfO;
            DeliveryDate = deliveryDate;
            IsActive = isActive;
        }
    }
}
