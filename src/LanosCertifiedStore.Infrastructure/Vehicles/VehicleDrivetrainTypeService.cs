using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;
using LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Vehicles;

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