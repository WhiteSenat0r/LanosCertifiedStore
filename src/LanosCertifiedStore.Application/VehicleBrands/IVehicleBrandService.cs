using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;

namespace LanosCertifiedStore.Application.VehicleBrands;

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