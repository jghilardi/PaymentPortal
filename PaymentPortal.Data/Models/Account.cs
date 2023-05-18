namespace PaymentPortal.Data.Models
{
    public class Account : Entity
    {
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int FkCustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
