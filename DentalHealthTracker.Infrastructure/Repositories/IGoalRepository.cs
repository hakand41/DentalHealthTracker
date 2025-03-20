using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface IGoalRepository : IGenericRepository<Goal>
    {
        Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId);
    }
}
