using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IHealthRecordService : IGenericService<HealthRecord>
    {
        Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId);
        Task<List<HealthRecord>> GetLast7DaysRecords(int userId);
        Task DeleteByGoalIdAsync(int goalId);
        Task<bool> HasHealthRecordsAsync(int goalId);
    }
}
