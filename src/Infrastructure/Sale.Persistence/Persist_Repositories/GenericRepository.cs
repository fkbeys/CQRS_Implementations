using Microsoft.EntityFrameworkCore;
using Sales.Application.App_Interfaces.Repository;
using Sales.Domain.Domain_Common;
using System.Linq.Expressions;

namespace Sales.Persistence.Persist_Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbset;

        public GenericRepository(DbContext dbContext)
        {
            dbset = dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbset.AddAsync((T)entities);
            return entities;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            dbset.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            T? record = await dbset.FirstOrDefaultAsync(x => x.id == id);
            return record;
        }

        public async Task<bool> isExist(Expression<Func<T, bool>> expression)
        {
            var record = await dbset.AnyAsync(expression);
            return record;
        }

        public async Task<T> Update(T entity)
        {
            dbset.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            dbset.UpdateRange(entities);
            return entities;
        }
    }
}
