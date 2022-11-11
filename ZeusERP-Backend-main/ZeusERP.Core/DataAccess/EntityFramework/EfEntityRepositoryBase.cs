
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Entities;

namespace ZeusERP.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using(var context = new TContext())
            {
                IQueryable<TEntity> entities = context.Set<TEntity>();
                return (filter == null)
                    ? entities.ToList()
                    : entities.Where(filter).ToList();
            }
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> entities = context.Set<TEntity>();

                return (filter == null)
                    ? await entities.ToListAsync()
                    : await entities.Where(filter).ToListAsync();
            }
        }

        public IList<TEntity> GetLimitedList(Expression<Func<TEntity, bool>> filter = null, int count = 0)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> entities = context.Set<TEntity>();
                return (filter == null)
                    ? entities.Take(count).ToList()
                    : entities.Where(filter).Take(count).ToList();
            }
        }

        public async Task<IList<TEntity>> GetLimitedListAsync(Expression<Func<TEntity, bool>> filter = null, int count = 0)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> entities = context.Set<TEntity>();
                return (filter == null)
                    ? await entities.Take(count).ToListAsync()
                    : await entities.Where(filter).Take(count).ToListAsync();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> entities = context.Set<TEntity>();
                return (filter == null)
                    ? entities.SingleOrDefault()
                    : entities.Where(filter).SingleOrDefault();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> entity = context.Set<TEntity>();

                return (filter == null)
                    ? await entity.SingleOrDefaultAsync()
                    : await entity.Where(filter).SingleOrDefaultAsync();
            }
        }

        public int Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                var entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Added;
                return context.SaveChanges();
            }
        }
        public async Task<int> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                return await context.SaveChangesAsync();
            }
        }

        public int Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entityToUpdate = context.Entry(entity);
                entityToUpdate.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entityToUpdate = context.Entry(entity);
                entityToUpdate.State = EntityState.Modified;
                return await context.SaveChangesAsync();
            }
        }

        public int Delete(TEntity entity)
        {
            using(var context = new TContext())
            {
                var entityToDelete = context.Entry(entity);
                entityToDelete.State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var entityToDelete = context.Entry(entity);
                entityToDelete.State = EntityState.Deleted;
                return await context.SaveChangesAsync();
            }
        }
    }
}
