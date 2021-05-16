using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltySystem.Business.Entities
{
    public class Configuration
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int PurchaseRewardPerPoint { get; set; }
        public int PurchaseRewardForPoint { get; set; }

    }
}
