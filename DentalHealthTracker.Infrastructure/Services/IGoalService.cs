using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IGoalService : IGenericService<Goal>
    {
        Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId);
        Task<List<Goal>> GetGoalsByUser(int userId);
        Task<bool> HasHealthRecordsAsync(int goalId);
        Task<Goal?> UpdateGoalAsync(int id, Goal updatedGoal);
        Task<bool> DeleteGoalAsync(int goalId);
        Task<bool> DeleteGoalAsync(int goalId, bool forceDelete = false);
    }
}
