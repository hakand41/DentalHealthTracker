namespace DentalHealthTracker.Core.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Kullanıcıya ait notlar

        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }  // Opsiyonel resim ekleme

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
    }
}
