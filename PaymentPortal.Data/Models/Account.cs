using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Account : Entity
    {
        [StringLength(16)]
        public required string AccountNumber { get; set; }
        [StringLength(24)]
        public required string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public ICollection<Payment> Payments { get; set; } = [];
    }
}
