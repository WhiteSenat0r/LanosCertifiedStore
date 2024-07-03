using Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;
using Application.Contracts.ServicesRelated;
using Application.Dtos.BrandDtos;
using Application.Dtos.Common;
using Application.QueryRequests.VehicleBrandsRelated.CollectionVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.CountVehicleBrandsQueryRelated;
using Application.QueryRequests.VehicleBrandsRelated.SingleVehicleBrandQueryRelated;
using Domain.Entities.VehicleRelated;
using Persistence.Commands.VehicleBrandRelated;
using Persistence.Queries.VehicleBrandRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleBrandService(
    CollectionVehicleBrandsQuery collectionQuery,
    SingleVehicleBrandQuery singleQuery,
    CountVehicleBrandsQuery countQuery,
    CreateVehicleBrandCommand createCommand,
    // IUpdateCommand<VehicleBrand> updateCommand,
    // IDeleteCommand<VehicleBrand> deleteCommand,
    Func<CancellationToken, Task<int>> saveChangesAction) : IVehicleBrandService
{
    public async Task<IReadOnlyCollection<VehicleBrandDto>> GetVehicleBrandCollection(
        CollectionVehicleBrandsQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<SingleVehicleBrandDto?> GetSingleVehicleBrand(
        SingleVehicleBrandQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await singleQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleBrandsCount(
        CountVehicleBrandsQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await countQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<Guid> AddNewVehicleBrand(
        CreateVehicleBrandCommandRequest commandRequest,
        CancellationToken cancellationToken)
    {
        var newVehicleBrand = new VehicleBrand(commandRequest.Name);

        await createCommand.Execute(newVehicleBrand, cancellationToken);

        await saveChangesAction(cancellationToken);

        return newVehicleBrand.Id;
    }
}