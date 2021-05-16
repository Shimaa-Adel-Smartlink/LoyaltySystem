using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltySystem.Business.Entities
{
    public class TransactionLog
    {
        public Guid Id { get; set; }
        public DateTime TransactionTimestamp { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Action { get; set; }
        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }

    }
}