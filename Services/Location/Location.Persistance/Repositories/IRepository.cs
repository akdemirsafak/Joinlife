using System.Linq.Expressions;

namespace Location.Persistance.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicates = null);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);
}
