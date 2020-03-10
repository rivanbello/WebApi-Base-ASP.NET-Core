using Segfy.Core.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Segfy.Core.Business.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity:Entity
    {
        Task Create(TEntity entidade);

        Task<IEnumerable<TEntity>> List();

        Task<IEnumerable<TEntity>> ListBy(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetById(Guid id);

        Task Update(TEntity entity);

        Task<int> SaveChanges();
    }
}
