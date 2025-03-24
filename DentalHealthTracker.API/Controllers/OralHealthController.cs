using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/oral-health")]
    [ApiController]
    [Authorize]
    public class OralHealthController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly INoteService _noteService;
        private readonly IGoalService _goalService;

        public OralHealthController(
            IHealthRecordService healthRecordService,
            INoteService noteService,
            IGoalService goalService)
        {
            _healthRecordService = healthRecordService;
            _noteService = noteService;
            _goalService = goalService;
        }

        // ✅ 1️⃣ Kullanıcının Son 7 Günlük Sağlık Kayıtları + Notlarını Getir
        [HttpGet("status")]
        public async Task<IActionResult> GetOralHealthStatus()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

            var healthRecords = await _healthRecordService.GetLast7DaysRecords(userId);
            var notes = await _noteService.GetNotesByUserAndDate(userId, sevenDaysAgo);

            return Ok(new
            {
                healthRecords,
                notes
            });
        }

        // ✅ 2️⃣ Kullanıcının Hedeflerini Getir
        [HttpGet("goals")]
        public async Task<IActionResult> GetUserGoals()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var goals = await _goalService.GetGoalsByUser(userId);

            return Ok(goals);
        }

        // ✅ 3️⃣ Kullanıcı Hedef Ekleyebilir
        [HttpPost("goals")]
        public async Task<IActionResult> AddGoal([FromBody] Goal goal)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            goal.UserId = int.Parse(userIdClaim);
            goal.CreatedAt = DateTime.UtcNow;
            goal.UpdatedAt = DateTime.UtcNow;

            await _goalService.AddAsync(goal);
            return Ok(goal);
        }

        // ✅ 4️⃣ Kullanıcı Hedef Silebilir
        [HttpDelete("goals/{goalId}")]
        public async Task<IActionResult> DeleteGoal(int goalId)
        {
            var goal = await _goalService.GetByIdAsync(goalId);
            if (goal == null) return NotFound("Hedef bulunamadı.");
            await _goalService.DeleteAsync(goal);
            return Ok("Hedef başarıyla silindi.");
        }


    }
}
