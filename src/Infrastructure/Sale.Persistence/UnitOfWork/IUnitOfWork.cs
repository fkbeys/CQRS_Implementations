using Sales.Application.App_Interfaces.Repository;

namespace Sales.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }

        Task SaveChangesAsync();
    }
}
