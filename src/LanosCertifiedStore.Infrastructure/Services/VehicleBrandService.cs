using Application.Shared.DtosRelated;
using Application.VehicleBrands;
using Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using Application.VehicleBrands.Dtos;
using Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using Domain.Entities.VehicleRelated;
using Persistence.Commands.Common;
using Persistence.Commands.VehicleBrandRelated;
using Persistence.Queries.VehicleBrandRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleBrandService(
    CollectionVehicleBrandsQuery collectionQuery,
    SingleVehicleBrandQuery singleQuery,
    CountVehicleBrandsQuery countQuery,
    CreateVehicleBrandCommand createCommand,
    UpdateVehicleBrandCommand updateVehicleBrandCommand,
    SaveChangesCommand saveChangesCommand) : IVehicleBrandService
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

        await saveChangesCommand.Execute(cancellationToken);

        return newVehicleBrand.Id;
    }

    public async Task UpdateVehicleBrand(UpdateVehicleBrandCommandRequest updateVehicleBrandCommandRequest,
        CancellationToken cancellationToken)
    {
        await updateVehicleBrandCommand.Execute(updateVehicleBrandCommandRequest);
        await saveChangesCommand.Execute(cancellationToken);
    }
}