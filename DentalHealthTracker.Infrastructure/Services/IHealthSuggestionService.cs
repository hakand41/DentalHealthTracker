using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IHealthSuggestionService : IGenericService<HealthSuggestion>
    {
        Task<HealthSuggestion?> GetRandomSuggestionAsync();
    }
}
