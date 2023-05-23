using Microsoft.EntityFrameworkCore;
using Sales.Application.App_Interfaces.Repository;
using Sales.Domain.Domain_Common;

namespace Sales.Persistence.Persist_Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbset;

        public GenericRepository(DbContext dbContext)
        {
            dbset = dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await dbset.AddAsync((T)entities);
            return entities;
        }

        public async Task<T> Delete(T entity)
        {
            dbset.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> DeleteRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            T? record = await dbset.FirstOrDefaultAsync(x => x.id == id);
            return record;
        }

        public async Task<T> Update(T entity)
        {
            dbset.Update(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities)
        {
            dbset.UpdateRange(entities);
            return entities;
        }
    }
}
