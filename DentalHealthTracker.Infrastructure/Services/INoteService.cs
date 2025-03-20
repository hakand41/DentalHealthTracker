using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface INoteService : IGenericService<Note>
    {
        Task<IEnumerable<Note>> GetUserNotesAsync(int userId);
    }
}
