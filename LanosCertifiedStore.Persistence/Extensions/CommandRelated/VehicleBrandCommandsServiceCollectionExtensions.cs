using Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.Dtos.BrandDtos;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.Common.Contracts;
using Persistence.Commands.VehicleBrandRelated;

namespace Persistence.Extensions.CommandRelated;

internal static class VehicleBrandCommandsServiceCollectionExtensions
{
    public static IServiceCollection AddVehicleBrandCommandsRelatedServices(this IServiceCollection services)
    {
        services.AddTransient<
            ICommand<VehicleBrand, CreateVehicleBrandCommandRequest, VehicleBrandDto>,
            CreateVehicleBrandCommand>();
        
        return services;
    }
}