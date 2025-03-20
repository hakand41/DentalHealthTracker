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
    }
}
