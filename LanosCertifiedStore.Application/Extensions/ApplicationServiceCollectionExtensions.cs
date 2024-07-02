using System.Reflection;
using Application.Behaviors;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
            typeof(CollectionVehicleBrandsQueryRequestHandler).Assembly));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        AddTransactionRelatedServices(services);
        AddValidationRelatedServices(services);

        return services;
    }

    private static void AddTransactionRelatedServices(IServiceCollection services) => 
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

    private static void AddValidationRelatedServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}