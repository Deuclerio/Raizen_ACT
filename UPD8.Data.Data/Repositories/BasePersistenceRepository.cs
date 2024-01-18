using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.Linq.Expressions;
using UPD8.Data.Data.Context;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Persistence;

namespace UPD8.Data.Data.Repositories
{
    public class BasePersistenceRepository<TEntity, TKey> : IBasePersistenceRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public readonly UPD8Context _context;

        public BasePersistenceRepository(UPD8Context context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }


        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task InsertListAsync(List<TEntity> entities)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task DeleteAsync(TKey id)
        {
            try
            {
                _context.Remove(await GetAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            try
            {
                return await _context.Database.BeginTransactionAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(JsonConvert.SerializeObject(ex));
            }
        }

    }
}
