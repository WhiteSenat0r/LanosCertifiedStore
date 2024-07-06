using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CollectionVehicleTransmissionTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleTransmissionTypeService(
    CollectionVehicleTransmissionTypesQuery collectionVehicleTransmissionTypesQuery,
    CountVehicleTransmissionTypesQuery countVehicleTransmissionTypesQuery) : IVehicleTransmissionTypeService
{
    public async Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleTransmissionTypesQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleTransmissionTypesCount(
        CountVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehicleTransmissionTypesQuery.Execute(queryRequest, cancellationToken);
    }
}