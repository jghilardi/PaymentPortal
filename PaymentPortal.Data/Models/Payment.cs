using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Payment : Entity
    {
        public decimal Amount { get; set; }
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        public bool IsVoid { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}