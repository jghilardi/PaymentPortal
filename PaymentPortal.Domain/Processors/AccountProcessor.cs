using PaymentPortal.Data.Interfaces;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Processors
{
    public class AccountProcessor(IAccountRepository accountRepository) : IAccountProcessor
    {
        public async Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request)
        {
            var response = new CreateAccountResponse();
            return response;
        }
    }
}
