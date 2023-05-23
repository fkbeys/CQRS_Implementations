using Sales.Domain.Domain_Common;

namespace Sales.Application.App_Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);
        Task<T> Delete(T entity);

        Task<IEnumerable<T>> DeleteRange(IEnumerable<T> entities);

    }
}
