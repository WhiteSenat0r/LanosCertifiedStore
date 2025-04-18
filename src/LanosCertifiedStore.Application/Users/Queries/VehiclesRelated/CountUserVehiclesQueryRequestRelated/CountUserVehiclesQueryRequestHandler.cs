using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using MediatR;

namespace LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.CountUserVehiclesQueryRequestRelated;

internal sealed class CountUserVehiclesQueryRequestHandler(IUserContext userContext, IVehicleService vehicleService) :
    IRequestHandler<CountUserVehiclesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountUserVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        (request.FilteringParameters as IVehicleFilteringRequestParameters)!.UserId = userContext.UserId;
        
        var userVehiclesCount = await vehicleService.GetUserVehiclesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(userVehiclesCount);
    }
}