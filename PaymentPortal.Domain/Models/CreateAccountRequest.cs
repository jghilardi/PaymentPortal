namespace PaymentPortal.Domain.Models
{
    public record CreateAccountRequest
    {
        public int CustomerId { get; init; }
        public required string AccountType { get; init; }
    }
}
