namespace PaymentPortal.API.Models
{
    public class PaymentRequest
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
