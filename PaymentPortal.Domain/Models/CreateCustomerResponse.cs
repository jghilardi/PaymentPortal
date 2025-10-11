namespace PaymentPortal.Domain.Models
{
    public record CreateCustomerResponse : BaseResponse
    {
        public required string FullName { get; init; }
        public int CustomerId { get; init; }
    }
}
