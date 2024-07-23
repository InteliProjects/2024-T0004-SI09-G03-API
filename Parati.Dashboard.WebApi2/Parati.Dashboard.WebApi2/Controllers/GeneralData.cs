using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/generalInfo")]
    [ApiController]
    public class GeneralDataController : Controller
    {
        private readonly IGeneralDataService _generalDataService;

        public GeneralDataController(IGeneralDataService generalDataService)
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