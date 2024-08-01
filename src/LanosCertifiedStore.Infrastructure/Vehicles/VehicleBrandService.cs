using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleBrands;
using LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CollectionVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.CountVehicleBrandsQueryRelated;
using LanosCertifiedStore.Application.VehicleBrands.Queries.SingleVehicleBrandQueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.VehicleBrandRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleBrandRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

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