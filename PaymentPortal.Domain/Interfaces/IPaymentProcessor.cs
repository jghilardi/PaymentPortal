using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Interfaces
{
    public interface IPaymentProcessor
    {
        Task<ProcessPaymentResponse> ProcessPaymentAsync(ProcessPaymentRequest request);
    }
}
