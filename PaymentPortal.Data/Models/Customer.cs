using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Customer : Entity
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
