using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleTypeRelated.CountVehicleTypesQueryRelated;

internal sealed class CountVehicleTypesQueryRequestHandler(IVehicleTypeService vehicleTypeService) : 
    IRequestHandler<CountVehicleTypesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountVehicleTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await vehicleTypeService.GetVehicleTypesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(count);
    }
}