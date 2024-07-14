using System.Reflection;
using Application.Shared;
using Application.Shared.ValidationRelated;
using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes;
using Persistence.Queries.Common.Contracts;
using Persistence.Services;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDatabaseContext>(option =>
        {
            option.UseNpgsql(config.GetConnectionString("PostgreSqlConnection"),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        services.AddCommandsAndQueriesRelatedServices();
        services.AddServicesForInterface(typeof(IQuerySortingSettingsSelector<>), ServiceLifetime.Transient);
        services.AddServicesForInterface(typeof(IQueryFilteringCriteriaSelector<>), ServiceLifetime.Transient);

        services.AddCommonServices();

        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IValidationHelper, ValidationHelper>();

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDatabaseContext>();


        return services;
    }

    private static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IQueryPaginator, QueryPaginator>();
        return services;
    }

    private static IServiceCollection AddServicesForInterface(
        this IServiceCollection services,
        Type interfaceType,
        ServiceLifetime lifetime)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var requests = GetClassesImplementingInterface(assembly, interfaceType);

        var serviceDescriptor = requests
            .Select(x =>
            {
                var implementedInterfaceType = x.GetInterfaces().First();
                return new ServiceDescriptor(implementedInterfaceType, x, lifetime);
            });

        services.TryAdd(serviceDescriptor);

        return services;
    }

    private static IServiceCollection AddCommandsAndQueriesRelatedServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var serviceDescriptors = assembly.ExportedTypes
            .Where(type => !type.IsInterface && !type.IsAbstract)
            .Where(type => type.Name.EndsWith("Query") || type.Name.EndsWith("Command"))
            .Select(type => new ServiceDescriptor(type, type, ServiceLifetime.Transient));

        services.TryAdd(serviceDescriptors);

        return services;
    }

    private static List<Type> GetClassesImplementingInterface(Assembly assembly, Type typeToMatch)
    {
        return assembly.GetTypes()
            .Where(type =>
            {
                var genericInterfaceTypes = type.GetInterfaces()
                    .Where(x => x.IsGenericType)
                    .ToList();

                var implementRequestType = genericInterfaceTypes
                    .Any(x => x.GetGenericTypeDefinition() == typeToMatch);

                return !type.IsInterface && !type.IsAbstract && implementRequestType;
            }).ToList();
    }
}