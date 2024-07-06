using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;
using
    Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.CountVehicleDrivetrainTypesQueryRequestRelated;
using Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleDrivetrainTypeService(
    CountVehicleDrivetrainTypesQuery countVehicleDrivetrainTypesQuery,
    CollectionVehicleDrivetrainTypesQuery collectionVehicleDrivetrainTypesQuery) : IVehicleDrivetrainTypeService
{
    public async Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> GetVehicleDrivetrainTypeCollection(
        CollectionVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleDrivetrainTypesQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleTypesCount(
        CountVehicleDrivetrainTypesQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await countVehicleDrivetrainTypesQuery.Execute(queryRequest, cancellationToken);
    }
}