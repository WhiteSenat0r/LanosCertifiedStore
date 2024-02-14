using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.UnitOfWorkRelated;

namespace Persistence.Extensions;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDatabaseContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("SqlServerConnection"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        AddRepositories(services);

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
        services.AddScoped<IRepository<VehicleBrand>, VehicleBrandRepository>();
        services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
        services.AddScoped<IRepository<VehicleColor>, VehicleColorRepository>();
        services.AddScoped<IRepository<VehicleDisplacement>, VehicleDisplacementRepository>();
        services.AddScoped<IRepository<VehicleModel>, VehicleModelRepository>();
        services.AddScoped<IRepository<VehiclePrice>, VehiclePriceRepository>();
    }
}