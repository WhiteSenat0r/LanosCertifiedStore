using System.Reflection;
using Application.Behaviors;
using Application.Helpers.ValidationRelated;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Application.Queries.Vehicles.VehiclesQueryRelated;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(VehiclesQueryHandler).Assembly));
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
        services.AddScoped(typeof(IValidationHelper), typeof(ValidationHelper));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}