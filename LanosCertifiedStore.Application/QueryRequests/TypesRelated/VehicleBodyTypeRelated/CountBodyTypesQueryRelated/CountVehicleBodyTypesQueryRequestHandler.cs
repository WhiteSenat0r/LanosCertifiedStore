using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;

internal sealed class CountBodyTypesQueryHandler(IVehicleBodyTypeService vehicleBodyTypeService)
    : IRequestHandler<CountVehicleBodyTypesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehicleBodyTypesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var itemsCountDto = await vehicleBodyTypeService.GetVehicleTypesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}