using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Account : Entity
    {
        public long AccountNumber { get; set; }
        [StringLength(24)]
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<AccountBalance> AccountBalances { get; set; } = new List<AccountBalance>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
