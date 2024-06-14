using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.Common;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated;

internal class VehicleModelRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleModelSelectionProfile,
        VehicleModel,
        VehicleModelEntity,
        IVehicleModelFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null!)
    {
        var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleModelEntity>, IReadOnlyList<VehicleModel>>(vehicleModels);
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        var vehicleModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleModelEntity>(), new VehicleModelFilteringRequestParameters
            {
                SelectionProfile = VehicleModelSelectionProfile.Single
            });

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleModel is not null 
            ? Mapper.Map<VehicleModelEntity, VehicleModel>(vehicleModel) 
            : null;
    }

    public override async Task AddNewEntityAsync(VehicleModel entity)
    {
        try
        {
           var model = await GetCreationPreparedModel(entity);
           
           await Context.Set<VehicleModelEntity>().AddAsync(model);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
        }
    }

    public override async Task UpdateExistingEntityAsync(VehicleModel entity)
    {
        var model = await GetUpdateModel(entity);
           
        Context.Set<VehicleModelEntity>().Update(model);
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleModelEntity>(),filteringRequestParameters);

        return countedQueryable.CountAsync();
    }
    
    private protected override IQueryable<VehicleModelEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleModelEntity>(),filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleModelSelectionProfile,
            VehicleModel,
            VehicleModelEntity,
            IVehicleModelFilteringRequestParameters> 
        GetQueryBuilder() =>
        new VehicleModelQueryBuilder(new VehicleModelSelectionProfiles(), new VehicleModelFilteringCriteria());
    
    private async Task<VehicleModelEntity> GetCreationPreparedModel(VehicleModel entity)
    {
        var mappedEntityModel = Mapper.Map<VehicleModel, VehicleModelEntity>(entity);

        await AssignCollectionToModel<VehicleBodyTypeEntity>(mappedEntityModel);
        await AssignCollectionToModel<VehicleEngineTypeEntity>(mappedEntityModel);
        await AssignCollectionToModel<VehicleTransmissionTypeEntity>(mappedEntityModel);
        await AssignCollectionToModel<VehicleDrivetrainTypeEntity>(mappedEntityModel);

        return mappedEntityModel;
    }
    
    private async Task<VehicleModelEntity> GetUpdateModel(VehicleModel entity)
    {
        var databaseModel = await QueryBuilder.GetSingleEntityQueryable(
            entity.Id, 
            Context.Set<VehicleModelEntity>(), new VehicleModelFilteringRequestParameters
            {
                SelectionProfile = VehicleModelSelectionProfile.Single
            }).SingleOrDefaultAsync();

        Context.Set<VehicleModelEntity>().Attach(databaseModel!);

        UpdateRelatesAspects(entity, databaseModel!);
        UpdateRelatedAspectCollections(entity, databaseModel!);

        return databaseModel!;
    }

    private void UpdateRelatedAspectCollections(VehicleModel entity, VehicleModelEntity databaseModel)
    {
        UpdateRelatedAspectCollection(
            entity, databaseModel!, e => e.AvailableBodyTypes, m => m.AvailableBodyTypes);
        UpdateRelatedAspectCollection(
            entity, databaseModel!, e => e.AvailableTransmissionTypes, m => m.AvailableTransmissionTypes);
        UpdateRelatedAspectCollection(
            entity, databaseModel!, e => e.AvailableDrivetrainTypes, m => m.AvailableDrivetrainTypes);
        UpdateRelatedAspectCollection(
            entity, databaseModel!, e => e.AvailableEngineTypes, m => m.AvailableEngineTypes);
    }

    private void UpdateRelatesAspects(VehicleModel entity, VehicleModelEntity databaseModel)
    {
        UpdateRelatedAspect(databaseModel!, entity, m => m.Name, e => e.Name, (m, e) => m.Name = e.Name);
        UpdateRelatedAspect(
            databaseModel!, entity, m => m.MinimalProductionYear, 
            e => e.MinimalProductionYear, (m, e) => m.MinimalProductionYear = e.MinimalProductionYear);
        UpdateRelatedAspect(
            databaseModel!, entity, m => m.MaximumProductionYear, 
            e => e.MaximumProductionYear, (m, e) => m.MaximumProductionYear = e.MaximumProductionYear);
        UpdateRelatedAspect(
            databaseModel!, entity, m => m.VehicleBrandId,
            e => e.Brand.Id, (m, e) => m.VehicleBrandId = e.Brand.Id);
        UpdateRelatedAspect(
            databaseModel!, entity, m => m.VehicleTypeId,
            e => e.VehicleType.Id, (m, e) => m.VehicleTypeId = e.VehicleType.Id);
    }

    private void UpdateRelatedAspect<T>(
        VehicleModelEntity databaseModel,
        VehicleModel entityModel,
        Func<VehicleModelEntity, T> propertySelector,
        Func<VehicleModel, T> newValueSelector,
        Action<VehicleModelEntity, VehicleModel> propertyUpdateAction)
    {
        if (!propertySelector(databaseModel)!.Equals(newValueSelector(entityModel)))
            propertyUpdateAction(databaseModel, entityModel);
    }

    
    private void UpdateRelatedAspectCollection<TEntity, TDataModel>(
        VehicleModel entity,
        VehicleModelEntity databaseVehicleModel,
        Func<VehicleModel, ICollection<TEntity>> entitySelector,
        Func<VehicleModelEntity, ICollection<TDataModel>> databaseModelSelector)
        where TEntity : class, IIdentifiable<Guid>
        where TDataModel : class, IIdentifiable<Guid>
    {
        var entityModelIds = entitySelector(entity)
            .Select(type => type.Id).ToList();
        var databaseModelIds = databaseModelSelector(databaseVehicleModel)
            .Select(type => type.Id).ToList();
        
        RemoveSpecifiedAspectPartsFromModel(
            databaseVehicleModel, databaseModelIds, entityModelIds, databaseModelSelector);
        AddSpecifiedAspectPartsToModel(
            entity, databaseVehicleModel, entityModelIds, databaseModelIds, entitySelector, databaseModelSelector);
    }

    private void AddSpecifiedAspectPartsToModel<TEntity, TDataModel>(
        VehicleModel entity, 
        VehicleModelEntity databaseVehicleModel,
        IEnumerable<Guid> entityModelIds,
        IEnumerable<Guid> databaseModelIds,
        Func<VehicleModel, ICollection<TEntity>> entitySelector,
        Func<VehicleModelEntity, ICollection<TDataModel>> databaseModelSelector)
        where TEntity : class, IIdentifiable<Guid>
        where TDataModel : class, IIdentifiable<Guid>
    {
        var addedTypeIdsToModel = entityModelIds.Except(databaseModelIds).ToList();

        foreach (var addedModelType in addedTypeIdsToModel.Select(typeId => entitySelector(entity)
                     .Single(type => type.Id.Equals(typeId))))
        {
            databaseModelSelector(databaseVehicleModel).Add(
                Mapper.Map<TEntity, TDataModel>(addedModelType));
        }
    }

    private void RemoveSpecifiedAspectPartsFromModel<TDataModel>(
        VehicleModelEntity databaseVehicleModel, 
        IEnumerable<Guid> databaseModelIds,
        IEnumerable<Guid> entityModelIds,
        Func<VehicleModelEntity, ICollection<TDataModel>> databaseModelSelector)
        where TDataModel : class, IIdentifiable<Guid>
    {
        var idsFromModel = databaseModelIds.Except(entityModelIds).ToList();

        foreach (var removedModelItem in idsFromModel.Select(id => databaseModelSelector(databaseVehicleModel)
                     .Single(item => item.Id.Equals(id)))) 
            databaseModelSelector(databaseVehicleModel).Remove(removedModelItem);
    }

    private async Task AssignCollectionToModel<T>(VehicleModelEntity mappedModel)
        where T : class, IIdentifiable<Guid>
    {
        var property = mappedModel.GetType().GetProperties()
            .Single(p => p.PropertyType == typeof(ICollection<T>));

        var value = property.GetValue(mappedModel)! as ICollection<T>;
        
        var ids = value!.Select(i => i.Id);

        var assignedCollection = await GetCollectionToAssign(ids, value);
            
        property.SetValue(mappedModel, assignedCollection);
    }

    private async Task<ICollection<T>> GetCollectionToAssign<T>(IEnumerable<Guid> ids, ICollection<T>? value)
        where T : class, IIdentifiable<Guid>
    {
        var assignedCollection = new List<T>();

        foreach (var id in ids)
        {
            var item = await Context.Set<T>().FindAsync(id);

            if (item is null)
                throw new ArgumentNullException(
                    value!.GetType().ToString(), "Aspect with such ID doesn't exist!");
            
            assignedCollection.Add(item);
        }

        return assignedCollection;
    }
}