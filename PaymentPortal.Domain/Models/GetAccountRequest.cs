namespace PaymentPortal.Domain.Models
{
    public record GetAccountRequest
    {
        public int CustomerId { get; init; }
        public string AccountNumber { get; init; }
    }
}
