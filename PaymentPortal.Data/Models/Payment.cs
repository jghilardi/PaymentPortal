namespace PaymentPortal.Data.Models
{
    public class Payment : Entity
    {
        public decimal Amount { get; set; }
        public int FkAccountId { get; set; }
        public Account Account { get; set; }
    }
}
