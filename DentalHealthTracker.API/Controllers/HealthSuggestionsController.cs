using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/health-suggestions")]
    [ApiController]
    public class HealthSuggestionsController : ControllerBase
    {
        private readonly IHealthSuggestionService _healthSuggestionService;

        public HealthSuggestionsController(IHealthSuggestionService healthSuggestionService)
        {
            _healthSuggestionService = healthSuggestionService;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddSuggestion([FromBody] HealthSuggestion suggestion)
        {
            var newSuggestion = await _healthSuggestionService.AddAsync(suggestion);
            return Ok(newSuggestion);
        }

        [Authorize]
        [HttpGet("random")]
        public async Task<IActionResult> GetRandomSuggestion()
        {
            var suggestion = await _healthSuggestionService.GetRandomSuggestionAsync();
            if (suggestion == null) return NotFound("Aktif öneri bulunamadı.");
            return Ok(suggestion);
        }
    }
}
