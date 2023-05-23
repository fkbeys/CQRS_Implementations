using Microsoft.EntityFrameworkCore;
using Sales.Application.App_Interfaces.Repository;
using Sales.Persistence.Persist_DbContext;
using Sales.Persistence.Persist_Repositories;

namespace Sales.Persistence.Persist_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public IProductRepository productRepository { get; private set; }

        public UnitOfWork(AppDbContext dbContext)
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
