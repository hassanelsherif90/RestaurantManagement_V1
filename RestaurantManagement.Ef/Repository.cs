using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Core.Models.Data;
using RestaurantManagement.Core.Repository;
using System.Linq.Expressions;

namespace RestaurantManagement.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly DbSet<T> _entities;


        public ApplicationDbcontext Dbcontext;

        public Repository(ApplicationDbcontext dbcontext)
        {
            Dbcontext = dbcontext;
            _entities = Dbcontext.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _entities.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }

            await _entities.AddRangeAsync(entities);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(e => !e.IsDeleted).AnyAsync(predicate);
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(e => !e.IsDeleted).CountAsync(predicate);
        }

        public virtual void RemoveAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
            _entities.Update(entity);
        }

        public virtual void RemoveRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
            }
            _entities.UpdateRange(entities);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities
                .Where(e => !e.IsDeleted)
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.Where(e => !e.IsDeleted).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual void UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _entities.Update(entity);
        }

    }
}
