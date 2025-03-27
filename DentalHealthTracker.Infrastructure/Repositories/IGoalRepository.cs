using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId);
        Task<List<Goal>> GetGoalsByUser(int userId);
        Task<bool> HasHealthRecordsAsync(int goalId);
        Task UpdateGoalAsync(Goal goal);
        Task<bool> DeleteGoalAsync(int goalId);
    }
}
