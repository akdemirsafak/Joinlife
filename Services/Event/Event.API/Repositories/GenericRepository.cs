using Event.API.Core;
using Event.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Event.API.Repositories
{
    public sealed class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EventyDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(EventyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter is null)
            {
                return _dbSet.ToListAsync();
            }
            return _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
