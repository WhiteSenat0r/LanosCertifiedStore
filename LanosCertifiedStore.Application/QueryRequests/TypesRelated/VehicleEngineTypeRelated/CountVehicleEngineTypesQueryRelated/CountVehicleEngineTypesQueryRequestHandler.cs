using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CountVehicleEngineTypesQueryRelated;

internal sealed class CountBodyTypesQueryHandler(IVehicleEngineTypeService vehicleEngineTypeService)
    : IRequestHandler<CountVehicleEngineTypesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehicleEngineTypesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var itemsCountDto = await vehicleEngineTypeService.GetVehicleEngineTypesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}