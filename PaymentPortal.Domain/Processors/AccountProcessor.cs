using AutoMapper;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Processors
{
    public class AccountProcessor(
        IAccountRepository accountRepository,
        IMapper mapper,
        ILogger<AccountProcessor> logger,
        HybridCache cache) : IAccountProcessor
    {

        public async Task<AccountResponse> GetAccountAsync(string accountNumber)
        {
            try
            {
                var response = new AccountResponse();
                var account = await cache.GetOrCreateAsync($"{accountNumber}", // key
                            async entry => await accountRepository.GetAccountByAccountNumberAsync(accountNumber));

                if (account != null && account.Id > 0)
                {
                    response = mapper.Map<AccountResponse>(account) with { IsSuccessful = true };
                }

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception on GetAccountAsync: {ex.Message}");
                return new AccountResponse();
            }
        }

        public async Task<AccountResponse> CreateAccountAsync(CreateAccountRequest request)
        {
            var response = new AccountResponse();
            return response;
        }
    }
}
