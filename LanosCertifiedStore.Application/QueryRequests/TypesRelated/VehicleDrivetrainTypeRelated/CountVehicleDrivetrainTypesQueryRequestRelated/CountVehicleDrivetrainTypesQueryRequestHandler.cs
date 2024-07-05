using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CountVehicleDrivetrainTypesQueryRequestRelated;

internal sealed class CountDrivetrainTypesQueryHandler(IVehicleDrivetrainTypeService vehicleDrivetrainTypeService)
    : IRequestHandler<CountVehicleDrivetrainTypesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(CountVehicleDrivetrainTypesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var itemsCountDto = await vehicleDrivetrainTypeService.GetVehicleTypesCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}