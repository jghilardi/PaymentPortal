namespace PaymentPortal.Domain.Models
{
    public record ProcessPaymentResponse : BaseResponse
    {
        public decimal AccountBalance { get; init; }
    }
}
