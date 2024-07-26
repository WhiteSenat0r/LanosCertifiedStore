using System.Reflection;
using FluentValidation;
using LanosCertifiedStore.Application.Behaviors;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CollectionVehicleBrandsQueryRequestHandler).Assembly);

            cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            cfg.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionPipelineBehavior<,>));
        });
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return services;
    }
}