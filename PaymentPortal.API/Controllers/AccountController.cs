using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentPortal.Domain.Models;
using System.Text.Json;

namespace PaymentPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("API/Payments")]

    public class AccountController(ILogger<AccountController> logger) : ControllerBase
    {
        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccountAsync(ProcessPaymentRequest request)
        {
            try
            {
                var response = new ProcessPaymentResponse();
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