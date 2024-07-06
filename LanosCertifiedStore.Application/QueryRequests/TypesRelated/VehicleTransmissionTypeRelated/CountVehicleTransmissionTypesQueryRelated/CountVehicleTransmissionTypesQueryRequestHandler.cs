using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CountVehicleTransmissionTypesQueryRelated;

internal sealed class CountVehicleTransmissionTypesQueryRequestHandler(
    IVehicleTransmissionTypeService vehicleTransmissionTypeService) : 
    IRequestHandler<CountVehicleTransmissionTypesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehicleTransmissionTypesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var itemsCountDto = await vehicleTransmissionTypeService
            .GetVehicleTransmissionTypesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}