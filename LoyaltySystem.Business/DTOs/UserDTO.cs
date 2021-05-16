using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltySystem.Business.DTOs
{
   public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Points { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<TransactionLogDTO> TransactionLogCreatedByNavigations { get; set; }
        public ICollection<TransactionLogDTO> TransactionLogUpdatedByNavigations { get; set; }
    }
}
