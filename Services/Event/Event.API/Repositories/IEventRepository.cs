using System.Linq.Expressions;
using Event.API.Entities;

namespace Event.API.Repositories;
public interface IEventRepository
{
    Task<List<Eventy>> GetAllAsync();
    Task<Eventy> GetAsync(Expression<Func<Eventy, bool>>? filter = null);
    Task<Eventy> CreateAsync(Eventy eventy);
    Task<Eventy> UpdateAsync(Eventy eventy);
    Task DeleteAsync(Eventy eventy);

}