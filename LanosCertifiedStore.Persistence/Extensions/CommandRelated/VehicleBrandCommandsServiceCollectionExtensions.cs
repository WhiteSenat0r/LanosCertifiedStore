using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.VehicleBrandRelated;

namespace Persistence.Extensions.CommandRelated;

internal static class VehicleBrandCommandsServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleBrandCommandsRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<CreateVehicleBrandCommand>();
        services.AddTransient<UpdateVehicleBrandCommand>();

        return services;
    }
}