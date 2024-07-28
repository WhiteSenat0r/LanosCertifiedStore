using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleModels;
using LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.VehicleModelRelated;
using LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleModelService(
    CollectionVehicleModelsQuery collectionVehicleModelsQuery,
    CollectionBrandlessVehicleModelsQuery collectionBrandlessVehicleModelsQuery,
    SingleVehicleModelQuery singleVehicleModelQuery,
    CountVehicleModelsQuery countVehicleModelsQuery,
    CreateVehicleModelCommand createVehicleModelCommand,
    UpdateVehicleModelCommand updateVehicleModelCommand,
    SaveChangesCommand saveChangesCommand) : IVehicleModelService
{
    public async Task<IReadOnlyCollection<VehicleModelDto>> GetVehicleModelCollection(
        CollectionVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleModelsQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<IReadOnlyCollection<VehicleModelWithoutBrandNameDto>> GetVehicleBrandlessModelCollection(
        CollectionBrandlessVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionBrandlessVehicleModelsQuery.Execute(queryRequest, cancellationToken);
    }
    
    public async Task<SingleVehicleModelDto?> GetSingleVehicleModel(
        SingleVehicleModelQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await singleVehicleModelQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleModelsCount(
        CountVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehicleModelsQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<Guid> AddNewVehicleModel(
        CreateVehicleModelCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await createVehicleModelCommand.Execute(request, cancellationToken);

        await saveChangesCommand.Execute(cancellationToken);

        return result;
    }

    public async Task UpdateVehicleModel(
        UpdateVehicleModelCommandRequest request,
        CancellationToken cancellationToken)
    {
        await updateVehicleModelCommand.Execute(request);
        
        await saveChangesCommand.Execute(cancellationToken);
    }
}