using Location.Persistance.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Location.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly LocationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public Repository(LocationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }
    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicates = null)
    {
        if (predicates == null)
            return await _dbSet.ToListAsync();
        return await _dbSet.Where(predicates).ToListAsync();
    }
    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null)
    {
        return await _dbSet.SingleOrDefaultAsync(predicate);
    }
}