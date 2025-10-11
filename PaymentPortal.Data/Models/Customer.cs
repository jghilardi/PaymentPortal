using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Customer : Entity
    {
        [StringLength(100)]
        public required string FirstName { get; set; }
        [StringLength(100)]
        public required string LastName { get; set; }
        [StringLength(250)]
        public required string Address { get; set; }

        public ICollection<Account> Accounts { get; set; } = [];
    }
}
