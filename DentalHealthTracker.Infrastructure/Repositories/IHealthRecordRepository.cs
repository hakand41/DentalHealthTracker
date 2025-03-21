using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface IHealthRecordRepository : IGenericRepository<HealthRecord>
    {
        Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId);
    }
}
