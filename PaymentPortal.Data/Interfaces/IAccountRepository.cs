using PaymentPortal.Data.Models;

namespace PaymentPortal.Data.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetAccountByAccountNumberAsync(string accountNumber);
    }
}
