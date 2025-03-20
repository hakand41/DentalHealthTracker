using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface IHealthSuggestionRepository : IGenericRepository<HealthSuggestion>
    {
        Task<HealthSuggestion?> GetRandomSuggestionAsync();
    }
}
