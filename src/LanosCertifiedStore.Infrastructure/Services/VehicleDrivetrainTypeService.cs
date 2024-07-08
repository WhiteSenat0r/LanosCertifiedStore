using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;
using Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleDrivetrainTypeService(
    CollectionVehicleDrivetrainTypesQuery collectionVehicleDrivetrainTypesQuery) : IVehicleDrivetrainTypeService
{
    public async Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> GetVehicleDrivetrainTypeCollection(
        CollectionVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleDrivetrainTypesQuery.Execute(queryRequest, cancellationToken);
    }
}