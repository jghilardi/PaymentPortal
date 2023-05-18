using Microsoft.AspNetCore.Mvc;
using PaymentPortal.API.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [ApiController]
    [Route("API/Payments")]

    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> logger;

        public PaymentsController(ILogger<PaymentsController> logger)
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