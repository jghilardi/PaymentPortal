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

    public class PaymentController(IPaymentProcessor paymentProcessor, ILogger<PaymentController> logger) : ControllerBase
    {
        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPaymentAsync(ProcessPaymentRequest request)
        {
            try
            {
                var response = await paymentProcessor.AddPaymentAsync(request);
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