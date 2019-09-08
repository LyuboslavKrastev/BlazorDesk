using BlazorDesk.Data.Services.Repository.Interfaces;
using BlazorDesk.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDesk.Data.Services.Repository
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class, IEntity
    {
        private readonly BlazorDeskDbContext dbContext;
        private DbSet<TEntity> dbSet;

        public DbRepository(BlazorDeskDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }
        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
             return this.dbSet.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return this.dbSet.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public IQueryable<TEntity> ById(int id)
        {
            return this.dbSet.Where(e => e.Id == id);
        }

        public void Delete(int id)
        {
            TEntity entity = this.ById(id).First();
            this.dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = this.All().Where(r => ids.Contains(r.Id));
            this.dbSet.RemoveRange(entities);
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }
    }
}
