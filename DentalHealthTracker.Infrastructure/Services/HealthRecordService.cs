using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Repositories;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class HealthRecordService : GenericService<HealthRecord>, IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;

        public HealthRecordService(IHealthRecordRepository healthRecordRepository) : base(healthRecordRepository)
        {
            _healthRecordRepository = healthRecordRepository;
        }

        public async Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId)
        {
            return await _healthRecordRepository.GetUserHealthRecordsAsync(userId);
        }

        public async Task<List<HealthRecord>> GetLast7DaysRecords(int userId)
        {
            var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);
            return await _healthRecordRepository.GetRecordsByUserAndDate(userId, sevenDaysAgo);
        }
    }
}
