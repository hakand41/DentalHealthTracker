using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/notes")]
    [ApiController]
    [Authorize]  // Sadece giriş yapmış kullanıcılar erişebilir
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNote([FromBody] Note note)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            note.UserId = int.Parse(userIdClaim);
            var newNote = await _noteService.AddAsync(note);
            return Ok(newNote);
        }

        [HttpGet("my-notes")]
        public async Task<IActionResult> GetMyNotes()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("Token geçersiz.");

            int userId = int.Parse(userIdClaim);
            var notes = await _noteService.GetUserNotesAsync(userId);
            return Ok(notes);
        }
    }
}
