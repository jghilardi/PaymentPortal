namespace PaymentPortal.Domain.Models
{
    public record BaseResponse
    {
        public bool IsSuccessful { get; init; }
        public string? Message { get; init; }
    }
}
