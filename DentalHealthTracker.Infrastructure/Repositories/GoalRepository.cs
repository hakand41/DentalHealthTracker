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

        public async Task<List<Goal>> GetGoalsByUser(int userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> HasHealthRecordsAsync(int goalId)
        {
            return await _context.HealthRecords.AnyAsync(hr => hr.GoalId == goalId);
        }
        
        public async Task UpdateGoalAsync(Goal goal)
        {
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();  // Veritabanına değişiklikleri kaydet
        }

        public async Task<bool> DeleteGoalAsync(int goalId)
        {
            var goal = await _context.Goals.FindAsync(goalId);
            if (goal == null) return false;

            if (await HasHealthRecordsAsync(goalId))
            {
                throw new InvalidOperationException("Bu hedefin ilişkili sağlık kayıtları olduğu için silinemez.");
            }

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }

         // Yeni overload:
        public async Task<bool> DeleteGoalAsync(int goalId, bool forceDelete = false)
        {
            // Goal + ilişkili HealthRecord’ları bir arada yükle
            var goal = await _context.Goals
                .Include(g => g.HealthRecords)
                .FirstOrDefaultAsync(g => g.Id == goalId);

            if (goal == null)
                return false;

            if (goal.HealthRecords.Any())
            {
                if (!forceDelete)
                    throw new InvalidOperationException(
                      "Bu hedefe ait sağlık kayıtları var. Zorla silmek için tekrar deneyin.");

                // Önce child kayıtları sil
                _context.HealthRecords.RemoveRange(goal.HealthRecords);
            }

            // Ardından goal’ü sil
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
