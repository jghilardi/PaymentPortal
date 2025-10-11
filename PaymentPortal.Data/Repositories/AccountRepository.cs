using Microsoft.EntityFrameworkCore;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Models;

namespace PaymentPortal.Data.Repositories
{
    public class AccountRepository(PaymentsDbContext dbContext) : BaseRepository<Account>(dbContext), IAccountRepository
    {
        public async Task<Account> GetAccountByAccountNumberAsync(string accountNumber)
        {
            try
            {
                var response = await context.Accounts.Where(x => x.AccountNumber == accountNumber).FirstOrDefaultAsync();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
