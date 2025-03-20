using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Repositories;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class HealthSuggestionService : GenericService<HealthSuggestion>, IHealthSuggestionService
    {
        private readonly IHealthSuggestionRepository _healthSuggestionRepository;

        public HealthSuggestionService(IHealthSuggestionRepository healthSuggestionRepository) : base(healthSuggestionRepository)
        {
            _healthSuggestionRepository = healthSuggestionRepository;
        }

        public async Task<HealthSuggestion?> GetRandomSuggestionAsync()
        {
            return await _healthSuggestionRepository.GetRandomSuggestionAsync();
        }
    }
}
