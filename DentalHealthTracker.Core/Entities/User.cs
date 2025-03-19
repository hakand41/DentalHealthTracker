namespace DentalHealthTracker.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
