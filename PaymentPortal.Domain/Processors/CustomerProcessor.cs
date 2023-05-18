using Microsoft.Extensions.Logging;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Models;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPortal.Domain.Processors
{
    public class CustomerProcessor : ICustomerProcessor
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger<CustomerProcessor> logger;

        public CustomerProcessor(ICustomerRepository customerRepository, ILogger<CustomerProcessor> logger)
        {
            this.customerRepository = customerRepository;
            this.logger = logger;
        }

        public async Task<int> AddCustomerAsync(CreateCustomerRequest request)
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
