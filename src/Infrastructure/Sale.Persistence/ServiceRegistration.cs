using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.App_Mappings;
using Sales.Persistence.Persist_DbContext;
using Sales.Persistence.Persist_UnitOfWork;

namespace Sales.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection servColl)
        {
            servColl.AddAutoMapper(typeof(MappingProfiles));

            servColl.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));

            servColl.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("MemoryDb");
                opt.EnableSensitiveDataLogging();
            });

            servColl.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
