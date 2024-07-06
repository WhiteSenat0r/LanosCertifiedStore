using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleBodyTypeService(
    CollectionVehicleBodyTypesQuery collectionVehicleBodyTypesQuery,
    CountVehicleBodyTypesQuery countVehicleBodyTypesQuery) : IVehicleBodyTypeService
{
    public async Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleBodyTypesQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleBodyTypesCount(CountVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehicleBodyTypesQuery.Execute(queryRequest, cancellationToken);
    }
}