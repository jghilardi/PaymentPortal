using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Account : Entity
    {
        public long AccountNumber { get; set; }
        [StringLength(24)]
        public required string AccountType { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public ICollection<AccountBalance> AccountBalances { get; set; } = [];
        public ICollection<Payment> Payments { get; set; } = [];
    }
}
