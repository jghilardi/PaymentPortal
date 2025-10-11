using Microsoft.Extensions.Logging;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Models;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;

namespace PaymentPortal.Domain.Processors
{
    public class CustomerProcessor(ICustomerRepository customerRepository, ILogger<CustomerProcessor> logger) : ICustomerProcessor
    {
        public async Task<int> CreateCustomerAsync(CreateCustomerRequest request)
        {
            try
            {
                var response = 0;

                var customer = await customerRepository.AddAsync(new Customer
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    CreateDateUtc = DateTime.UtcNow
                });

                if (customer != null)
                {
                    response = customer.Id;
                }

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to add customer.  Exception: {ex}");
                return 0;
            }
        }
    }
}
