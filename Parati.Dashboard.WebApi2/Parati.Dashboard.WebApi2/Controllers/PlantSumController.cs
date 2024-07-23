using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/plantsum")]
    [ApiController]
    public class PlantSumController : Controller
    {
        private readonly IPlantSumService _plantSumService;

        public PlantSumController(IPlantSumService plantSumService)
        {
            _plantSumService = plantSumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanSum()
        {
            try
            {
                var result = await _plantSumService.GetPlanSum();
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