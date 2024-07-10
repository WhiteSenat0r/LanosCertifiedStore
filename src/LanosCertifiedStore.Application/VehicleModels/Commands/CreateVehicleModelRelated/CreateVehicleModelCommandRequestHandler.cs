using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleModels.Commands.CreateVehicleModelRelated;

internal sealed class CreateVehicleModelCommandRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<CreateVehicleModelCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateVehicleModelCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var createdModelId = await vehicleModelService.AddNewVehicleModel(request, cancellationToken);

            return Result<Guid>.Success(createdModelId);
        }
        catch (KeyNotFoundException e)
        {
            return Result<Guid>.Failure(Error.NotFound(e.Message));
        }
    }
}