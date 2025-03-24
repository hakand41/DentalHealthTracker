using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public class HealthRecordRepository : GenericRepository<HealthRecord>, IHealthRecordRepository
    {
        public HealthRecordRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId)
        {
            return await _context.HealthRecords
                .Where(hr => hr.UserId == userId)
                .OrderByDescending(hr => hr.RecordDate)
                .ToListAsync();
        }

         public async Task<List<HealthRecord>> GetRecordsByUserAndDate(int userId, DateTime fromDate)
        {
            return await _context.HealthRecords
                .Where(hr => hr.UserId == userId && hr.RecordDate >= fromDate)
                .ToListAsync();
        }
    }
}
