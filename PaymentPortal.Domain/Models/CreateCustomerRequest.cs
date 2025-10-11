namespace PaymentPortal.Domain.Models
{
    public record CreateCustomerRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Address { get; init; }
    }
}
