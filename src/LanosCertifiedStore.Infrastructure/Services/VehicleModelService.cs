using Application.Shared.DtosRelated;
using Application.VehicleModels;
using Application.VehicleModels.Commands.CreateVehicleModelRelated;
using Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using Application.VehicleModels.Dtos;
using Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;
using Persistence.Commands.Common;
using Persistence.Commands.VehicleModelRelated;
using Persistence.Queries.VehicleModelRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

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
        CollectionVehicleBrandlessModelsQueryRequest queryRequest,
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