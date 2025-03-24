using DentalHealthTracker.Core.DTOs;
using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize] // Kullanıcının giriş yapmış olması gerekir
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz veya süresi dolmuş.");

            int userId = int.Parse(userIdClaim);
            var user = await _userService.GetByIdAsync(userId);
            if (user == null) return NotFound("Kullanıcı bulunamadı.");

            return Ok(new
            {
                user.Id,
                user.Email,
                user.FullName,
                user.BirthDate
            });
        }

        [Authorize]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] User updatedUser)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var user = await _userService.UpdateUserAsync(userId, updatedUser.FullName, updatedUser.BirthDate);
            if (user == null) return BadRequest("Güncelleme başarısız.");

            return Ok(user);
        }

        [Authorize]
        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var user = await _userService.UpdateUserPasswordAsync(userId, model.OldPassword, model.NewPassword);
            if (user == null) return BadRequest("Şifre güncelleme başarısız.");

            return Ok("Şifre başarıyla değiştirildi.");
        }

    }
}
