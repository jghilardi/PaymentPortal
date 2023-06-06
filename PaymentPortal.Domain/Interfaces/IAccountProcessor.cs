using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Interfaces
{
    public interface IAccountProcessor
    {
        Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request);
    }
}
