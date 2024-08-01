using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleModelRelated;

public sealed class UpdateVehicleModelCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(UpdateVehicleModelCommandRequest request)
    {
        var updatedModel = await context.Set<VehicleModel>()
            .Include(model => model.AvailableDrivetrainTypes)
            .Include(model => model.AvailableEngineTypes)
            .Include(model => model.AvailableBodyTypes)
            .Include(model => model.AvailableTransmissionTypes)
            .SingleOrDefaultAsync(m => m.Id.Equals(request.Id));

        if (updatedModel is null)
        {
            ThrowNotFoundException<VehicleModel>(request.Id);
        }

        await UpdateModelAspects(request, updatedModel!);

        context.Set<VehicleModel>().Update(updatedModel!);
    }

    private async Task UpdateModelAspects(UpdateVehicleModelCommandRequest request, VehicleModel updatedModel)
    {
        await UpdateAspectCollection<VehicleBodyType>(
            request.AvailableBodyTypesIds, updatedModel, nameof(updatedModel.AvailableBodyTypes));
        
        await UpdateAspectCollection<VehicleEngineType>(
            request.AvailableEngineTypesIds, updatedModel, nameof(updatedModel.AvailableEngineTypes));
        
        await UpdateAspectCollection<VehicleDrivetrainType>(
            request.AvailableDrivetrainTypesIds, updatedModel, nameof(updatedModel.AvailableDrivetrainTypes));
        
        await UpdateAspectCollection<VehicleTransmissionType>(
            request.AvailableTransmissionTypesIds, updatedModel, nameof(updatedModel.AvailableTransmissionTypes));

        if (IsNewMaximumProductionYearAssignable(request, updatedModel))
        {
            updatedModel.MaximumProductionYear = request.MaximumProductionYear;
        }
    }

    private async Task UpdateAspectCollection<TEntity>(
        IEnumerable<Guid> ids, VehicleModel updatedModel, string propertyName) 
        where TEntity : class, IIdentifiable<Guid>
    {
        var aspects = await GetAspectCollection<TEntity>(ids);
        
        updatedModel.GetType().GetProperty(propertyName)!.SetValue(updatedModel, aspects);
    }

    private bool IsNewMaximumProductionYearAssignable(
        UpdateVehicleModelCommandRequest request,
        VehicleModel updatedModel)
    {
        var isMaximumYearGreaterThanMinimum = 
            request.MaximumProductionYear!.Value >= updatedModel.MinimalProductionYear;
        
        if (request.MaximumProductionYear.HasValue && updatedModel.MaximumProductionYear.HasValue)
        {
            return !updatedModel.MaximumProductionYear.Value.Equals(request.MaximumProductionYear.Value) &&
                   isMaximumYearGreaterThanMinimum;
        }
        
        return isMaximumYearGreaterThanMinimum;
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
                ThrowNotFoundException<TEntity>(id);
            }
            
            items.Add(item!);
        }

        return items;
    }
    
    private void ThrowNotFoundException<TEntity>(Guid id) where TEntity : class, IIdentifiable<Guid>
    {
        throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} was not found!");
    }
}