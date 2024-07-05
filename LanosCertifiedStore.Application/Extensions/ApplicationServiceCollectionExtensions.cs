using System.Reflection;
using Application.Behaviors;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationServiceCollectionExtensions
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