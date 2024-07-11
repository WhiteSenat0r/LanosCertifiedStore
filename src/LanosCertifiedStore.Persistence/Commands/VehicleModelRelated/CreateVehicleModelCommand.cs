using Application.VehicleModels.Commands.CreateVehicleModelRelated;
using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.VehicleModelRelated;

public sealed class CreateVehicleModelCommand(ApplicationDatabaseContext context)
{
    public async Task<Guid> Execute(
        CreateVehicleModelCommandRequest request, CancellationToken cancellationToken)
    {
        var bodyTypes = await GetAspectCollection<VehicleBodyType>(request.AvailableBodyTypesIds);
        var engineTypes = await GetAspectCollection<VehicleEngineType>(request.AvailableEngineTypesIds);
        var drivetrainTypes = await GetAspectCollection<VehicleDrivetrainType>(request.AvailableDrivetrainTypesIds);
        var transmissionTypes = await GetAspectCollection<VehicleTransmissionType>(request.AvailableTransmissionTypesIds);

        var newModel = new VehicleModel(
            request.BrandId,
            request.TypeId,
            request.Name,
            engineTypes,
            transmissionTypes,
            drivetrainTypes,
            bodyTypes,
            request.MinimalProductionYear,
            request.MaximumProductionYear);
        
        await context.Set<VehicleModel>().AddAsync(newModel, cancellationToken);

        return newModel.Id;
    }

    private async Task<ICollection<TEntity>> GetAspectCollection<TEntity>(IEnumerable<Guid> identifiers)
        where TEntity : class, IIdentifiable<Guid>
    {
        var items = new List<TEntity>();
        var set = context.Set<TEntity>();

        foreach (var id in identifiers)
        {
            var item = await set.FindAsync(id);

            if (item is null)
            {
                throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} was not found!");
            }
            
            items.Add(item);
        }

        return items;
    }
}