using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/engagementInfo")]
    [ApiController]
    public class EngagementController : Controller
    {
        private readonly IEngagementeService _generalDataService;

        public EngagementController(IEngagementeService generalDataService)
        {
            _generalDataService = generalDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                var result = await _generalDataService.GetData();
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