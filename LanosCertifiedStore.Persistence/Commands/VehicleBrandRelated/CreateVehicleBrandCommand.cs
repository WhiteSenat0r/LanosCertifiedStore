using Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Commands.Common.Classes;
using Persistence.Commands.Common.Classes.Constants;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Commands.VehicleBrandRelated;

internal sealed class CreateVehicleBrandCommand(ApplicationDatabaseContext context, IMapper mapper) : 
    CommandBase<VehicleBrand, CreateVehicleBrandCommandRequest, VehicleBrandDto>
{
    public override async Task<Result<VehicleBrand>> Execute(
        CreateVehicleBrandCommandRequest commandRequest,
        CancellationToken cancellationToken)
    {
        try
        {
            var brandEntity = new VehicleBrandEntity(commandRequest.Name);
            
            await context.Set<VehicleBrandEntity>().AddAsync(brandEntity, cancellationToken);

            var brand = mapper.Map<VehicleBrandEntity, VehicleBrand>(brandEntity);
            
            return Result<VehicleBrand>.Success(brand);
        }
        catch (Exception)
        {
            return Result<VehicleBrand>.Failure(
                new Error(CommandConstants.CommandExecutionErrorCode, CommandConstants.CommandExecutionErrorMessage));
        }
    }
}