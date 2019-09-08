using BlazorDesk.Data.Services.Interfaces;
using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Data.Services.BaseClasses
{
    public abstract class BaseDbService<T> : IDbService<T> where T : class, IEntity
    {
        protected readonly IRepository<T> repository;

        protected BaseDbService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual ValueTask<EntityEntry<T>> AddAsync(T entity)
        {
            return this.repository.AddAsync(entity);
        }

        public virtual Task AddRangeAsync(IEnumerable<T> entities)
        {
            return this.repository.AddRangeAsync(entities);
        }

        public virtual IQueryable<T> ById(int id)
        {
            return this.repository.ById(id);
        }

        public virtual IQueryable<T> ById(int id, string userId, bool isTechnician)
        {
            return this.repository.ById(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.repository.All();
        }

        public virtual async Task DeleteRange(IEnumerable<int> ids)
        {
            this.repository.DeleteRange(ids);

            await this.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            this.repository.Delete(id);

            await this.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return this.repository.SaveChangesAsync();
        }

 
    }
}
