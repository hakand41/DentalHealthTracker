using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IHealthRecordService : IGenericService<HealthRecord>
    {
        Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId);
    }
}
