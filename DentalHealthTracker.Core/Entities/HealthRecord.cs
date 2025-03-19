namespace DentalHealthTracker.Core.Entities
{
    public class HealthRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoalId { get; set; }
        public DateTime RecordDate { get; set; }
        public TimeSpan RecordTime { get; set; }
        public int Duration { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
        public Goal? Goal { get; set; }
    }
}
