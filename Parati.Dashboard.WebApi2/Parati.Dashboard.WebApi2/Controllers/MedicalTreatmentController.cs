using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/medicalTreatment")]
    [ApiController]
    public class MedicalTreatmentController : Controller
    {
        private readonly IMedicalTreatmentService _medicalTreatmentService;

        public MedicalTreatmentController(IMedicalTreatmentService medicalTreatmentService)
        {
            _medicalTreatmentService = medicalTreatmentService;
        }

        [HttpGet("{planta}")]
        public async Task<IActionResult> getMedicalTreatment([FromRoute] string planta)
        {
            try
            {
                var result = await _medicalTreatmentService.getMedicalTreatment(planta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: Log.Error(ex, "Failed to get GPTW information.");
                return StatusCode(500,
                    "An error occurred while processing your request. Please try again later. " + ex);
            }
        }
    }
}