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

        public async Task<bool> HasHealthRecordsAsync(int goalId)
        {
            return await _goalRepository.HasHealthRecordsAsync(goalId);
        }

        public async Task<Goal?> UpdateGoalAsync(int id, Goal updatedGoal)
        {
            var existingGoal = await _goalRepository.GetByIdAsync(id);
            if (existingGoal == null)
            {
                return null;
            }

            // Güncellenebilir alanlar
            existingGoal.Title = updatedGoal.Title;
            existingGoal.Description = updatedGoal.Description;
            existingGoal.Period = updatedGoal.Period;
            existingGoal.Importance = updatedGoal.Importance;
            existingGoal.IsActive = updatedGoal.IsActive;
            existingGoal.UpdatedAt = DateTime.UtcNow;

            await _goalRepository.UpdateGoalAsync(existingGoal);  // Doğru metodu çağır
            return existingGoal;
        }

        public async Task<bool> DeleteGoalAsync(int goalId)
        {
            return await _goalRepository.DeleteGoalAsync(goalId);
        }
    }
}
