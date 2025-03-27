using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/goals")]
    [ApiController]
    [Authorize]  // Giriş yapmış kullanıcılar erişebilir
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddGoal([FromBody] Goal goal)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            goal.UserId = int.Parse(userIdClaim);
            var newGoal = await _goalService.AddAsync(goal);
            return Ok(newGoal);
        }

        [HttpGet("my-goals")]
        public async Task<IActionResult> GetMyGoals()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var goals = await _goalService.GetUserGoalsAsync(userId);
            return Ok(goals);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] Goal updatedGoal)
        {
            if (updatedGoal == null)
            {
                return BadRequest("Invalid goal data.");
            }

            var result = await _goalService.UpdateGoalAsync(id, updatedGoal);
            if (result == null)
            {
                return NotFound("Goal not found.");
            }

            return Ok(result);
        }
    }
}
