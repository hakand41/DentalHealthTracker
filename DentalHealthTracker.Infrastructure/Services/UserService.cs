using DentalHealthTracker.Core.Entities;
using DentalHealthTracker.Infrastructure.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User?> UpdateUserAsync(int userId, string fullName, DateTime birthDate)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;

            user.FullName = fullName;
            user.BirthDate = birthDate;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(user);
            return user;
        }

        public async Task<User?> UpdateUserPasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;

            if (!VerifyPassword(oldPassword, user.PasswordHash, user.PasswordSalt))
                return null;

            (string newHash, string newSalt) = HashPassword(newPassword);
            user.PasswordHash = newHash;
            user.PasswordSalt = newSalt;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(user);
            return user;
        }

        private static (string hash, string salt) HashPassword(string password)
        {
            using var hmac = new HMACSHA256();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return (hash, salt);
        }

        private static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using var hmac = new HMACSHA256(Convert.FromBase64String(storedSalt));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return computedHash == storedHash;
        }
    }
}
