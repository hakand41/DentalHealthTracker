using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IGoalService : IGenericService<Goal>
    {
        Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId);
        Task<List<Goal>> GetGoalsByUser(int userId);
    }
}
