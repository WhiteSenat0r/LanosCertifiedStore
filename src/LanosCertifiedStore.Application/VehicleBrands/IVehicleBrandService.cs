using Application.Shared.DtosRelated;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using Application.VehicleBrands.Dtos;
using Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;

namespace Application.VehicleBrands;

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

    Task<Guid> AddNewVehicleBrand(
        CreateVehicleBrandCommandRequest commandRequest, CancellationToken cancellationToken);

    Task UpdateVehicleBrand(
        UpdateVehicleBrandCommandRequest updateVehicleBrandCommandRequest, CancellationToken cancellationToken);
}