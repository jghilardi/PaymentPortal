using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Payment : Entity
    {
        public decimal Amount { get; set; }
        public bool PaymentType { get; set; }
        public int AccountId { get; set; }
        public required Account Account { get; set; }
    }
}