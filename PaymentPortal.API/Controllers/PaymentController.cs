using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [ApiController]
    [Route("API/Payments")]

    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPaymentAsync(ProcessPaymentRequest request)
        {
            try
            {
                logger.LogInformation(JsonSerializer.Serialize(request));
                var response = new ProcessPaymentResponse();
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