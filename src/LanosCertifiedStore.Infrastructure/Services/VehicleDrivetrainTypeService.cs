using Application.VehicleDrivetrainTypes;
using Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;
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