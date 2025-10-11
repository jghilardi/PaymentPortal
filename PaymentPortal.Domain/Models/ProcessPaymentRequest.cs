namespace PaymentPortal.Domain.Models
{
    public record ProcessPaymentRequest
    {
        public int AccountNumber { get; init; }
        public decimal Amount { get; init; }
    }
}
