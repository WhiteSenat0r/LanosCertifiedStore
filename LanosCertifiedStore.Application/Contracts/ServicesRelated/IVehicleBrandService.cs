using Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.Dtos.BrandDtos;
using Application.Dtos.Common;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleBrandService
{
    Task<IReadOnlyCollection<VehicleBrandDto>> GetVehicleBrandCollection(
        CollectionVehicleBrandsQueryRequest queryRequest,
        CancellationToken cancellationToken);
    Task<SingleVehicleBrandDto?> GetSingleVehicleBrand(
        SingleVehicleBrandQueryRequest queryRequest,
        CancellationToken cancellationToken);
    Task<ItemsCountDto> GetVehicleBrandsCount(
        CountVehicleBrandsQueryRequest queryRequest,
        CancellationToken cancellationToken);
    Task<Guid> AddNewVehicleBrand(CreateVehicleBrandCommandRequest commandRequest, CancellationToken cancellationToken);
}