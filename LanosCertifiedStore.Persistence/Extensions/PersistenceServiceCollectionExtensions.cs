using Application.Contracts.ServicesRelated.RequestRelated;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.Factories.QueryRelated.Common.Classes;
using Persistence.Factories.QueryRelated.Common.Contracts;
using Persistence.Queries.Common.Classes;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.VehicleBrandRelated;
using Persistence.Services.QueryRelated;

namespace Persistence.Extensions;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDatabaseContext>(option =>
        {
            option.UseNpgsql(config.GetConnectionString("PostgreSqlConnection"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        AddVehicleBrandQueriesRelatedServices(services);
        AddQueryRelatedServices(services);

        return services;
    }

    private static void AddQueryRelatedServices(IServiceCollection services)
    {
        services.AddScoped<IQueryPaginator, QueryPaginator>();
        services.AddScoped<IQueryFactory, QueryFactory>(provider => InitializeQueryFactory(services, provider));
        services.AddScoped<IQueryService, QueryService>();
    }

    private static void AddVehicleBrandQueriesRelatedServices(IServiceCollection services)
    {
        services.AddTransient<IQuerySortingSettingsSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsSortingSettingsSelector>();
        services.AddTransient<IQueryProjectionProfileSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsProjectionProfileSelector>();
        services.AddTransient<IQueryFilteringCriteriaSelector<VehicleBrand, VehicleBrandEntity>,
            VehicleBrandsFilteringCriteriaSelector>();
        services.AddTransient<IQuery<VehicleBrand, IReadOnlyCollection<VehicleBrand>>, VehicleBrandsQuery>();
    }

    private static QueryFactory InitializeQueryFactory(IServiceCollection services, IServiceProvider provider)
    {
        var queryDescriptors = services.Where(
            serviceDescriptor => serviceDescriptor.ServiceType.IsGenericType &&
                                 serviceDescriptor.ServiceType.GetGenericTypeDefinition() == typeof(IQuery<,>))
            .ToList();

        var serviceTypes = queryDescriptors.Select(d => d.ServiceType);

        var queries = serviceTypes.Select(type => provider.GetService(type)!).ToList();

        var queryFactory = new QueryFactory(queries);

        return queryFactory;
    }
}