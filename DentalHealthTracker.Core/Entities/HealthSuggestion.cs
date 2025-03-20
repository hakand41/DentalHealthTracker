namespace DentalHealthTracker.Core.Entities
{
    public class HealthSuggestion
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;  // Öneri içeriği
        public bool IsActive { get; set; } = true;  // Önerinin aktif olup olmadığını kontrol etmek için

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
