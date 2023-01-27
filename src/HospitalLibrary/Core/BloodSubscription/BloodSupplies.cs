using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public class BloodSupplies
    {
        public int Id { get; set; }
        public int AmountOfA { get; set; }
        public int AmountOfB { get; set;}
        public int AmountOfAB { get; set;}
        public int AmountOfO { get; set;}

        public BloodSupplies()
        {

        }

        public BloodSupplies(int id, int amountOfA, int amountOfB, int amountOfAB, int amountOfO)
        {
            Id = id;
            AmountOfA = amountOfA;
            AmountOfB = amountOfB;
            AmountOfAB = amountOfAB;
            AmountOfO = amountOfO;
        }
    }
}
