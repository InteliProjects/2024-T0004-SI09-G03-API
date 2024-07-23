using Microsoft.AspNetCore.Mvc;
using Parati.Dashboard.Services;

namespace Parati.Dashboard.WebApi.Controllers
{
    [Route("api/QuestionScore")]
    [ApiController]
    public class QuestionScoreController : Controller
    {
        private readonly IQuestionScoreService _questionScoreService;

        public QuestionScoreController(IQuestionScoreService questionScoreService)
        {
            _questionScoreService = questionScoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionScore()
        {
            try
            {
                var result = await _questionScoreService.GetQuestionScore();
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