using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;

internal sealed class CountVehicleBrandsQueryRequestRequestHandler(IVehicleBrandService vehicleBrandService) : 
    IRequestHandler<CountVehicleBrandsQueryRequest, Result<ItemsCountDto>>
{
    public Task<Result<ItemsCountDto>> Handle(
        CountVehicleBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}