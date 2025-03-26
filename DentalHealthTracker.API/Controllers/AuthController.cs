using DentalHealthTracker.Core.DTOs;
using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Helpers;
using DentalHealthTracker.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DentalHealthTracker.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUserService userService, JwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user, [FromServices] MailService mailService)
        {
            if (await _userService.GetByEmailAsync(user.Email) != null)
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");

            PasswordHasher.CreatePasswordHash(user.PasswordHash, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PasswordSalt = Convert.ToBase64String(passwordSalt);

            await _userService.AddAsync(user);

            // Kullanıcıya HTML formatında hoş geldin maili gönder
            string emailSubject = "Hoş Geldiniz - Dental Health Tracker";
            string emailBody = $@"
                <html>
                    <body>
                        <h2>Merhaba {user.FullName},</h2>
                        <p>Dental Health Tracker'a kayıt olduğunuz için teşekkür ederiz!</p>
                        <p>Sağlıklı bir ağız bakımı için uygulamamızı kullanabilirsiniz.</p>
                        <p><strong>Email:</strong> {user.Email}</p>
                        <p><a href='https://dentalhealthtracker.com'>Giriş Yap</a></p>
                        <br>
                        <p>Dental Health Tracker Ekibi</p>
                    </body>
                </html>";

            await mailService.SendEmailAsync(user.Email, emailSubject, emailBody);

            return Ok("Kullanıcı başarıyla oluşturuldu. Aktivasyon e-postası gönderildi.");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            var user = await _userService.GetByEmailAsync(loginRequest.Email);
            if (user == null) return Unauthorized("E-posta veya parola yanlış.");

            bool isPasswordValid = PasswordHasher.VerifyPassword(
                loginRequest.PasswordHash, 
                Convert.FromBase64String(user.PasswordHash), 
                Convert.FromBase64String(user.PasswordSalt)
            );

            if (!isPasswordValid) return Unauthorized("E-posta veya parola yanlış.");

            string token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);
            return Ok(new { token });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null) return NotFound("Bu e-posta adresine sahip bir kullanıcı bulunamadı.");

            // Yeni şifre hash'leniyor
            PasswordHasher.CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = Convert.ToBase64String(passwordHash);
            user.PasswordSalt = Convert.ToBase64String(passwordSalt);

            await _userService.UpdateAsync(user);
            return Ok("Şifreniz başarıyla güncellendi.");
        }

    }
}
