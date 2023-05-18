using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Interfaces
{
    public interface ICustomerProcessor
    {
        Task<int> CreateCustomerAsync(CreateCustomerRequest request);
    }
}
