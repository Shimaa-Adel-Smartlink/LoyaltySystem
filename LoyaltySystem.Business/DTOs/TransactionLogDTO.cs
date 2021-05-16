using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltySystem.Business.DTOs
{
  public  class TransactionLogDTO
    {
        public Guid Id { get; set; }
        public DateTime TransactionTimestamp { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Action { get; set; }
        public UserDTO CreatedByNavigation { get; set; }
        public UserDTO UpdatedByNavigation { get; set; }
    }
}
