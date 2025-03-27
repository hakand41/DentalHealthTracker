using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Repositories
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<IEnumerable<Note>> GetUserNotesAsync(int userId);
        Task<List<Note>> GetNotesByUserAndDate(int userId, DateTime fromDate);
        Task<bool> DeleteNoteAsync(int noteId);
    }
}
