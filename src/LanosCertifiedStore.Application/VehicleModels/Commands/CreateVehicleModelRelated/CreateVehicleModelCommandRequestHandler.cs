using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;

internal sealed class CreateVehicleModelCommandRequestHandler(IVehicleModelService vehicleModelService) :
    IRequestHandler<CreateVehicleModelCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateVehicleModelCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createdModelId = await vehicleModelService.AddNewVehicleModel(request, cancellationToken);

        return createdModelId;
    }
}