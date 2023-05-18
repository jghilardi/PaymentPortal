using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [ApiController]
    [Route("API/Customers")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerProcessor customerProcessor;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(ICustomerProcessor customerProcessor, ILogger<CustomerController> logger)
        {
            this.customerProcessor = customerProcessor;
            this.logger = logger;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerRequest request)
        {
            try
            {
                logger.LogInformation(JsonSerializer.Serialize(request));
                var response = await customerProcessor.AddCustomerAsync(request);
                logger.LogInformation(JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError($"High level exception: {ex}");
                return NotFound();
            }
        }
    }
}
