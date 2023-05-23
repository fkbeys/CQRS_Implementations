using Sales.Domain.Domain_Common;
using System.Linq.Expressions;

namespace Sales.Application.App_Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> isExist(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
        Task<T> DeleteAsync(T entity);

        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities);

    }
}
