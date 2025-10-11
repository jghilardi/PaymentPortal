using AutoMapper;
using Microsoft.Extensions.Logging;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Processors
{
    public class PaymentProcessor(
        IAccountProcessor accountProcessor, 
        ILogger<PaymentProcessor> logger) : IPaymentProcessor
    {
        public async Task<ProcessPaymentResponse> AddPaymentAsync(ProcessPaymentRequest request)
        {
            var response = new ProcessPaymentResponse();
            var account = await accountProcessor.GetAccountAsync(request.AccountNumber);

            if (account.IsSuccessful)
            {
                
            }

            return response;
        }
    }
}