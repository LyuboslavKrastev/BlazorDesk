using BlazorDesk.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Data.Services.Interfaces
{
    public interface IDbService<T> where T : class, IEntity
    {
        IQueryable<T> ById(int id);
        IQueryable<T> GetAll();

        ValueTask<EntityEntry<T>> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task Delete(int id);
        Task DeleteRange(IEnumerable<int> ids);

        Task SaveChangesAsync();
    }
}
