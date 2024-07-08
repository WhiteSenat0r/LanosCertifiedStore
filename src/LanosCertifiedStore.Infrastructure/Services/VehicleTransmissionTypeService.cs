using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CollectionVehicleTransmissionTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleTransmissionTypeService(
    CollectionVehicleTransmissionTypesQuery collectionVehicleTransmissionTypesQuery) : IVehicleTransmissionTypeService
{
    public async Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleTransmissionTypesQuery.Execute(queryRequest, cancellationToken);
    }
}