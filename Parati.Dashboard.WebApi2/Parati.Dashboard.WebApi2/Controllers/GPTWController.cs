using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/gptw")]
    [ApiController]
    public class GPTWController : Controller
    {
        private readonly IGptwService _gptwService;

        public GPTWController(IGptwService gptwService)
        {
            _gptwService = gptwService;
        }

        [HttpGet("{unidade}")]
        public async Task<IActionResult> GetGptw([FromRoute] string unidade)
        {
            try
            {
                var result = await _gptwService.GetGptw(unidade);
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