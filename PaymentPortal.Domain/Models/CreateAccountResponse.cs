namespace PaymentPortal.Domain.Models
{
    public record CreateAccountResponse : BaseResponse
    {
        public string? CustomerName { get; init; }
        public long AccountNumber { get; init; }
        public string? AccountType { get; init; }
    }
}
