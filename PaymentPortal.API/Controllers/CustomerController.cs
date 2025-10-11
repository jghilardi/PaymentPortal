using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("API/Customers")]

    public class CustomerController(ICustomerProcessor customerProcessor, ILogger<CustomerController> logger) : ControllerBase
    {
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerRequest request)
        {
            try
            {
                var response = await customerProcessor.CreateCustomerAsync(request);
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
