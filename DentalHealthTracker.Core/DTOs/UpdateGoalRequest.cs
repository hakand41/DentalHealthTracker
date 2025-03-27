namespace DentalHealthTracker.Core.DTOs
{
    public class UpdateGoalRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
    }
}
