using Application.Commands.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Commands.Common.Classes;
using Persistence.Commands.Common.Classes.Constants;
using Persistence.Contexts.ApplicationDatabaseContext;

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
            var brandEntity = new VehicleBrand(commandRequest.Name);
            
            await context.Set<VehicleBrand>().AddAsync(brandEntity, cancellationToken);

            var brand = mapper.Map<VehicleBrand, VehicleBrand>(brandEntity);
            
            return Result<VehicleBrand>.Success(brand);
        }
        catch (Exception)
        {
            return Result<VehicleBrand>.Failure(
                new Error(CommandConstants.CommandExecutionErrorCode, CommandConstants.CommandExecutionErrorMessage));
        }
    }
}