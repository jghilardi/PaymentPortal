using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [ApiController]
    [Route("API/Payments")]

    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;

        public AccountController(ILogger<AccountController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccountAsync(ProcessPaymentRequest request)
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