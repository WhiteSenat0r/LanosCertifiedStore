using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.Common;

namespace Persistence.Extensions.CommandRelated;

internal static class CommandsServiceCollectionExtensions
{
    public static IServiceCollection AddCommandRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<SaveChangesCommand>();
        
        services.AddVehicleBrandCommandsRelatedServices();

        return services;
    }
}