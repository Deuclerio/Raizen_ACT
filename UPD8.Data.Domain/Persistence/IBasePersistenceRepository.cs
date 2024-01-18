using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Domain.Persistence
{
    public interface IBasePersistenceRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> InsertAsync(TEntity entity);
        Task InsertListAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
