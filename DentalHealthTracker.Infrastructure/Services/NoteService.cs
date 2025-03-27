using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Repositories;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class NoteService : GenericService<Note>, INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository) : base(noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> GetUserNotesAsync(int userId)
        {
            return await _noteRepository.GetUserNotesAsync(userId);
        }

        public async Task<List<Note>> GetNotesByUserAndDate(int userId, DateTime fromDate)
        {
            return await _noteRepository.GetNotesByUserAndDate(userId, fromDate);
        }

        public async Task<bool> DeleteNoteAsync(int noteId)
        {
            return await _noteRepository.DeleteNoteAsync(noteId);
        }

        public async Task<Note?> UpdateNoteAsync(int id, Note updatedNote)
        {
            var existingNote = await _noteRepository.GetByIdAsync(id);
            if (existingNote == null) return null;

            existingNote.Description = updatedNote.Description;
            existingNote.ImagePath = updatedNote.ImagePath;
            existingNote.CreatedAt = updatedNote.CreatedAt;  // Tarih güncellenmek istenirse
            await _noteRepository.UpdateAsync(existingNote);  // Generic Repository kullanarak
            return existingNote;
        }
    }
}
