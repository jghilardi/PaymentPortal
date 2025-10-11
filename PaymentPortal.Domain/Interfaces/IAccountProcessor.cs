using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Interfaces
{
    public interface IAccountProcessor
    {
        Task<AccountResponse> GetAccountAsync(string accountNumber);
        Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request);
    }
}
