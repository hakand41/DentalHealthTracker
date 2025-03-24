using DentalHealthTracker.Core.Entities;

namespace DentalHealthTracker.Infrastructure.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> UpdateUserAsync(int userId, string fullName, DateTime birthDate);
        Task<User?> UpdateUserPasswordAsync(int userId, string oldPassword, string newPassword);
    }
}
