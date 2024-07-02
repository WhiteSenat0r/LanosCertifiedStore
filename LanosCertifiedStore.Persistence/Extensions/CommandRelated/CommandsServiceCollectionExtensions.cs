using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions.CommandRelated;

internal static class CommandsServiceCollectionExtensions
{
    public static IServiceCollection AddCommandRelatedServices(this IServiceCollection services)
    {
        services.AddVehicleBrandCommandsRelatedServices();

        return services;
    }
}