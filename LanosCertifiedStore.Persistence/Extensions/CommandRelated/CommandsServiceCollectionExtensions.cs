using Application.Contracts.ServicesRelated.RequestRelated;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.Common.Contracts;
using Persistence.Factories.CommandRelated.Common.Classes;
using Persistence.Factories.CommandRelated.Common.Contracts;
using Persistence.Services;

namespace Persistence.Extensions.CommandRelated;

internal static class CommandsServiceCollectionExtensions
{
    public static IServiceCollection AddCommandRelatedServices(this IServiceCollection services)
    {
        AddCommonServices(services);
        
        services.AddVehicleBrandCommandsRelatedServices();

        return services;
    }

    private static void AddCommonServices(IServiceCollection services)
    {
        services.AddScoped<ICommandFactory, CommandFactory>(provider => InitializeQueryFactory(services, provider));
        services.AddScoped<ICommandService, CommandService>();
    }

    private static CommandFactory InitializeQueryFactory(IServiceCollection services, IServiceProvider provider)
    {
        var commandDescriptors = services.Where(
                serviceDescriptor => serviceDescriptor.ServiceType.IsGenericType &&
                                     serviceDescriptor.ServiceType.GetGenericTypeDefinition() == typeof(ICommand<,,>))
            .ToList();

        var serviceTypes = commandDescriptors.Select(d => d.ServiceType);

        var commands = serviceTypes.Select(type => provider.GetService(type)!).ToList();

        var commandFactory = new CommandFactory(commands);

        return commandFactory;
    }
}