namespace DentalHealthTracker.Core.Entities
{
    public class Goal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string Importance { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
        public ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
    }
}
