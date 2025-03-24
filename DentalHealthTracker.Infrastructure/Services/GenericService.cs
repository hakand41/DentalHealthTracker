using DentalHealthTracker.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace DentalHealthTracker.Infrastructure.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _repository.FindAsync(predicate);

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            return await _repository.SaveChangesAsync() > 0;
        }
    }
}
