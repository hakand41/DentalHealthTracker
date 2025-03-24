using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Repositories;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class GoalService : GenericService<Goal>, IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository) : base(goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId)
        {
            return await _goalRepository.GetUserGoalsAsync(userId);
        }

        public async Task<List<Goal>> GetGoalsByUser(int userId)
        {
            return await _goalRepository.GetGoalsByUser(userId);
        }

    }
}
