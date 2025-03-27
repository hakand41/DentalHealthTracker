using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface INoteService : IGenericService<Note>
    {
        Task<IEnumerable<Note>> GetUserNotesAsync(int userId);
        Task<List<Note>> GetNotesByUserAndDate(int userId, DateTime fromDate);
        Task<bool> DeleteNoteAsync(int noteId);
    }
}
