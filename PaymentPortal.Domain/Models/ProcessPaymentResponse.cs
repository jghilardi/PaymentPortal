namespace PaymentPortal.Domain.Models
{
    public record ProcessPaymentResponse
    {
        public bool IsSuccessful { get; init; }
        public decimal AccountBalance { get; init; }
    }
}
