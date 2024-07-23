using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/gptw")]
    [ApiController]
    public class GPTWVWController : Controller
    {
        private readonly IGptwVWService _gptwVWService;

        public GPTWVWController(IGptwVWService gptwVWService)
        {
            _gptwVWService = gptwVWService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGptwVW()
        {
            try
            {
                var result = await _gptwVWService.GetGptwVW();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Failed to get GPTW information.");
                return StatusCode(500, "An error occurred while processing your request. Please try again later. " + ex);
            }
        }
    }
}