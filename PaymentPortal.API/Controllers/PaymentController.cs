using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("API/Payments")]

    public class PaymentController(ILogger<PaymentController> logger) : ControllerBase
    {
        private readonly IPaymentProcessor paymentProcessor;

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPaymentAsync(ProcessPaymentRequest request)
        {
            try
            {
                logger.LogInformation(JsonSerializer.Serialize(request));
                var response = await paymentProcessor.ProcessPaymentAsync(request);
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