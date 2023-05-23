using Microsoft.EntityFrameworkCore;
using Sales.Application.App_Interfaces.Repository;
using Sales.Domain.Domain_Entities;

namespace Sales.Persistence.Persist_Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
