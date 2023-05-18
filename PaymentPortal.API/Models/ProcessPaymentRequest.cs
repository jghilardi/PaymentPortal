namespace PaymentPortal.API.Models
{
    public class ProcessPaymentRequest
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
