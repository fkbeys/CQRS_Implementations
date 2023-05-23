using Microsoft.EntityFrameworkCore;
using Sales.Application.App_Interfaces.Repository;
using Sales.Persistence.Persist_Repositories;

namespace Sales.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            productRepository = new ProductRepository(dbContext);
            this.dbContext = dbContext;
        }


        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
