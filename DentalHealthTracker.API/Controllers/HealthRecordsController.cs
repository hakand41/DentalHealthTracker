using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/healthrecords")]
    [ApiController]
    [Authorize]  // Sadece giriş yapmış kullanıcılar erişebilir
    public class HealthRecordsController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordsController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddHealthRecord([FromBody] HealthRecord healthRecord)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            healthRecord.UserId = int.Parse(userIdClaim);
            var newRecord = await _healthRecordService.AddAsync(healthRecord);
            return Ok(newRecord);
        }

        [HttpGet("my-records")]
        public async Task<IActionResult> GetMyHealthRecords()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var records = await _healthRecordService.GetUserHealthRecordsAsync(userId);
            return Ok(records);
        }
    }
}
