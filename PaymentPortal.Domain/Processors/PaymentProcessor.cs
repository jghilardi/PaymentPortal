using PaymentPortal.Data.Interfaces;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Processors
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountBalanceRepository accountBalanceRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IPaymentRepository paymentRepository;

        public PaymentProcessor(IAccountRepository accountRepository, IAccountBalanceRepository accountBalanceRepository, ICustomerRepository customerRepository, IPaymentRepository paymentRepository)
        {
            this.accountRepository = accountRepository;
            this.accountBalanceRepository = accountBalanceRepository;
            this.customerRepository = customerRepository;
            this.paymentRepository = paymentRepository;
        }

        public async Task<ProcessPaymentResponse> ProcessPaymentAsync(ProcessPaymentRequest request)
        {
            var response = new ProcessPaymentResponse();

            return response;
        }
    }
}