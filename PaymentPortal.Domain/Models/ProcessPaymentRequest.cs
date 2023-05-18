namespace PaymentPortal.API.Models
{
    public class ProcessPaymentRequest
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
