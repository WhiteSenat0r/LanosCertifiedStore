using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CountVehicleTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleTypeService(
    CollectionVehicleTypesQuery collectionQuery,
    CountVehicleTypesQuery countQuery) : IVehicleTypeService
{
    public async Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleTypesCount(
        CountVehicleTypesQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await countQuery.Execute(queryRequest, cancellationToken);
    }
}