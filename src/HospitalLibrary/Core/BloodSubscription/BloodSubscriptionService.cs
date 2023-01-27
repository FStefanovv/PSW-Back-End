using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.BloodSubscription
{
    public class BloodSubscriptionService: IBloodSubscriptionService
    {

        private readonly IBloodSubscriptionRepository _bloodSubscriptionRepository;
        private readonly IBloodSuppliesRepository _bloodSuppliesRepository;
        public BloodSubscriptionService(IBloodSuppliesRepository bloodSuppliesRepository, IBloodSubscriptionRepository bloodSubscriptionRepository) {
            _bloodSubscriptionRepository = bloodSubscriptionRepository;
            _bloodSuppliesRepository= bloodSuppliesRepository;
       
        }

        public void CancelSubscription(BloodSubscription subscription)
        {
            subscription.IsActive = false;
            _bloodSubscriptionRepository.Cancel(subscription);

        }

        public void CreateSubscription(BloodSubscription subscription)
        {
            subscription.IsActive= true;
           _bloodSubscriptionRepository.Create(subscription);
        }

        public BloodSubscription GetActive()
        {
           return _bloodSubscriptionRepository.GetActive();
        }

        public BloodSupplies GetSupplies()
        {
            return _bloodSuppliesRepository.GetById(1);
        }

        public void RecieveSupplies()
        {
            BloodSupplies supplies = GetSupplies();
            BloodSubscription subscription = GetActive();
            supplies.AmountOfAB = +subscription.AmountOfAB;
            supplies.AmountOfO = +subscription.AmountOfO;
            supplies.AmountOfB = +subscription.AmountOfB;
            supplies.AmountOfA= +subscription.AmountOfA;
            _bloodSuppliesRepository.Update(supplies);
        }
    }
}
