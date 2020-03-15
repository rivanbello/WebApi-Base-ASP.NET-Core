using Microsoft.EntityFrameworkCore;
using Segfy.Core.Business.Interfaces.Repositories.Base;
using Segfy.Core.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Segfy.Data.Persistence.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly SegfyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(SegfyContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ListBy(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }

        public bool Exists(Func<TEntity, bool> where)
        {
            return DbSet.AsNoTracking().Any(where);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
