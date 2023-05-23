using Sales.Application.App_Interfaces.Repository;

namespace Sales.Persistence.Persist_UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }

        Task SaveChangesAsync();
    }
}
