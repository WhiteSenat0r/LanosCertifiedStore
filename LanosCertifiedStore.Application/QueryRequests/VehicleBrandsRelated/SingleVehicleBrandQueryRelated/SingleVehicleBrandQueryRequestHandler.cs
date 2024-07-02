using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

internal sealed class SingleVehicleBrandQueryRequestHandler(IVehicleBrandService vehicleBrandService) : 
    IRequestHandler<SingleVehicleBrandQueryRequest, Result<VehicleBrandDto>>
{
    public Task<Result<VehicleBrandDto>> Handle(
        SingleVehicleBrandQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
