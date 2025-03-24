using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/home")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IHealthSuggestionService _healthSuggestionService;

        public HomeController(IHealthRecordService healthRecordService, IHealthSuggestionService healthSuggestionService)
        {
            _healthRecordService = healthRecordService;
            _healthSuggestionService = healthSuggestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeData()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);

            // Son 7 günlük sağlık kayıtlarını getir
            var recentHealthRecords = await _healthRecordService.GetLast7DaysRecords(userId);

            // Rastgele bir sağlık önerisi getir
            var randomSuggestion = await _healthSuggestionService.GetRandomSuggestionAsync();

            return Ok(new
            {
                recentHealthRecords,
                randomSuggestion
            });
        }
    }
}
