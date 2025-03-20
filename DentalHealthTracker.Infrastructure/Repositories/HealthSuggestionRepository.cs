using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public class HealthSuggestionRepository : GenericRepository<HealthSuggestion>, IHealthSuggestionRepository
    {
        public HealthSuggestionRepository(ApplicationDbContext context) : base(context) { }

        public async Task<HealthSuggestion?> GetRandomSuggestionAsync()
        {
            return await _context.HealthSuggestions
                .Where(s => s.IsActive)
                .OrderBy(r => Guid.NewGuid()) // Rastgele sıralama
                .FirstOrDefaultAsync();
        }
    }
}
