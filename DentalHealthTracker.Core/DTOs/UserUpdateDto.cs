namespace DentalHealthTracker.Core.DTOs
{
    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string CurrentPassword { get; set; } = string.Empty; // Şifre değiştirme için
        public string NewPassword { get; set; }  = string.Empty;// Yeni şifre
    }
}
