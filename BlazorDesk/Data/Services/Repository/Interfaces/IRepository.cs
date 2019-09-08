using BlazorDesk.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Data.Services.Repository.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> ById(int id);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void DeleteRange(IEnumerable<int> entities);
        void Delete(int id);
        Task<int> SaveChangesAsync();
    }
}
