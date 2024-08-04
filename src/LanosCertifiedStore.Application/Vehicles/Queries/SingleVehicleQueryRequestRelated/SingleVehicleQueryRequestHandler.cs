using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;

internal sealed class SingleVehicleQueryRequestHandler(
    IVehicleService vehicleService,
    IIdentityProviderService identityProviderService) :
    IRequestHandler<SingleVehicleQueryRequest, Result<SingleVehicleDto>>
{
    public async Task<Result<SingleVehicleDto>> Handle(
        SingleVehicleQueryRequest request,
        CancellationToken cancellationToken)
    {
        var vehicle = await vehicleService.GetVehicle(request, cancellationToken);

        if (vehicle is null)
        {
            return Result<SingleVehicleDto>.Failure(Error.NotFound(request.ItemId));
        }

        var owner = await identityProviderService.GetUserDataAsync(vehicle.OwnerId, cancellationToken);

        vehicle.OwnerData = new OwnerDto(
            owner.Value!.FirstName,
            owner.Value.LastName,
            owner.Value.Email,
            owner.Value.PhoneNumber);

        return vehicle;
    }
}