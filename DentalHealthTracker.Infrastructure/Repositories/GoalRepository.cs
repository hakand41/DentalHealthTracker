using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        public GoalRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Goal>> GetUserGoalsAsync(int userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }
    }
}
