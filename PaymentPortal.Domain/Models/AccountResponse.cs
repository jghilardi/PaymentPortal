using PaymentPortal.Data.Models;

namespace PaymentPortal.Domain.Models
{
    public record AccountResponse : BaseResponse
    {
        public string AccountNumber { get; init; }
        public string? AccountType { get; init; }
        public decimal AccountBalance { get; init; }
        public string? CustomerName { get; init; }
        public Customer? Customer { get; init; }
        public List<Payment> Payments { get; init; } = [];
    }
}
