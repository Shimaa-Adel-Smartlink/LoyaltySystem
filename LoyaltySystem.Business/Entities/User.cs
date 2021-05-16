using System;
using System.Collections.Generic;

namespace LoyaltySystem.Business.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Points { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<TransactionLog> TransactionLogCreatedByNavigations { get; set; }
        public ICollection<TransactionLog> TransactionLogUpdatedByNavigations { get; set; }
    }
}
