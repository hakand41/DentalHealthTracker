using System.Linq.Expressions;
using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface IHealthRecordRepository : IGenericRepository<HealthRecord>
    {
        Task<IEnumerable<HealthRecord>> GetUserHealthRecordsAsync(int userId);
        Task<List<HealthRecord>> GetRecordsByUserAndDate(int userId, DateTime fromDate);
        Task<bool> AnyAsync(Expression<Func<HealthRecord, bool>> predicate);
        //Task<IEnumerable<HealthRecord>> FindAsync(Expression<Func<HealthRecord, bool>> predicate);
    }
}
