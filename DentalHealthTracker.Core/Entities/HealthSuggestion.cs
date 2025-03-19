namespace DentalHealthTracker.Core.Entities
{
    public class HealthSuggestion
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
