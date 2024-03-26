using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleModelRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleModelRelated;

internal class VehicleModelRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleModelSelectionProfile,
        VehicleModel,
        VehicleModelDataModel,
        IVehicleModelFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null!)
    {
        var vehicleModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleModels = await vehicleModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleModelDataModel>, IReadOnlyList<VehicleModel>>(vehicleModels);
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        var vehicleModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleModelDataModel>(), new VehicleModelFilteringRequestParameters
            {
                SelectionProfile = VehicleModelSelectionProfile.Single
            });

        var vehicleModel = await vehicleModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleModel is not null 
            ? Mapper.Map<VehicleModelDataModel, VehicleModel>(vehicleModel) 
            : null;
    }

    public override async Task AddNewEntityAsync(VehicleModel entity)
    {
        var mappedEntityModel = Mapper.Map<VehicleModel, VehicleModelDataModel>(entity);
        
        await AssignTypeCollectionToModel(entity, mappedEntityModel);

        await Context.Set<VehicleModelDataModel>().AddAsync(mappedEntityModel);
    }
    
    public override async Task UpdateExistingEntityAsync(VehicleModel entity)
    {
        var databaseVehicleModel = await GetModelFromDatabase(entity);
        
        UpdateModelRelatedTypes(entity, databaseVehicleModel!);
        UpdateModelRelatedBrand(entity, databaseVehicleModel!);
        UpdateModelName(entity, databaseVehicleModel!);

        Context.Set<VehicleModelDataModel>().Update(databaseVehicleModel!);
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleModelDataModel>(),filteringRequestParameters);

        return countedQueryable.CountAsync();
    }
    
    private protected override IQueryable<VehicleModelDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleModelDataModel>(),filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleModelSelectionProfile,
            VehicleModel,
            VehicleModelDataModel,
            IVehicleModelFilteringRequestParameters> 
        GetQueryBuilder() =>
        new VehicleModelQueryBuilder(new VehicleModelSelectionProfiles(), new VehicleModelFilteringCriteria());
    
    private Task<VehicleModelDataModel?> GetModelFromDatabase(VehicleModel entity) =>
        Context.Set<VehicleModelDataModel>()
            .Include(model => model.VehicleType)
            .FirstOrDefaultAsync(model => model.Id.Equals(entity.Id));

    private async Task AssignTypeCollectionToModel(VehicleModel entity, VehicleModelDataModel mappedEntityModel)
    {
        // TODO
        // var types = await GetRequiredTypesAsync(entity);
        //
        // mappedEntityModel.VehicleType = types;
    }
    
    private async Task<List<VehicleTypeDataModel>> GetRequiredTypesAsync(VehicleModel entity)
    {
        var types = new List<VehicleTypeDataModel>();

        foreach (var typeId in entity.AvailableTypes.Select(x => x.Id))
        {
            var type = await Context.Set<VehicleTypeDataModel>().FindAsync(typeId);
        
            if (type is not null) types.Add(type);
        }

        return types;
    }
    
    private void UpdateModelName(VehicleModel entity, VehicleModelDataModel databaseVehicleModel)
    {
        if (!databaseVehicleModel.Name.Equals(entity.Name))
            databaseVehicleModel.Name = entity.Name;
    }

    private void UpdateModelRelatedBrand(VehicleModel entity, VehicleModelDataModel databaseVehicleModel)
    {
        if (!databaseVehicleModel.VehicleBrandId.Equals(entity.Brand.Id))
            databaseVehicleModel.VehicleBrandId = entity.Brand.Id;
    }

    private void UpdateModelRelatedTypes(VehicleModel entity, VehicleModelDataModel databaseVehicleModel)
    {
        // TODO
        // var entityModelTypeIds = entity.AvailableTypes.Select(type => type.Id).ToList();
        // var databaseModelTypeIds = databaseVehicleModel!.VehicleType.Select(type => type.Id).ToList();
        //
        // RemoveSpecifiedTypesFromModel(databaseVehicleModel, databaseModelTypeIds, entityModelTypeIds);
        // AddSpecifiedTypesToModel(entity, databaseVehicleModel, entityModelTypeIds, databaseModelTypeIds);
    }

    private void AddSpecifiedTypesToModel(VehicleModel entity, 
        VehicleModelDataModel databaseVehicleModel,
        IEnumerable<Guid> entityModelTypeIds,
        IEnumerable<Guid> databaseModelTypeIds)
    {
        // TODO
        // var addedTypeIdsToModel = entityModelTypeIds.Except(databaseModelTypeIds).ToList();
        //
        // foreach (var typeId in addedTypeIdsToModel)
        // {
        //     var addedModelType = entity.AvailableTypes.First(type => type.Id.Equals(typeId));
        //     databaseVehicleModel.VehicleType.Add(
        //         Mapper.Map<VehicleType, VehicleTypeDataModel>(addedModelType));
        // }
    }

    private void RemoveSpecifiedTypesFromModel(VehicleModelDataModel databaseVehicleModel, 
        IEnumerable<Guid> databaseModelTypeIds,
        IEnumerable<Guid> entityModelTypeIds)
    {
        // TODO
        // var removedTypeIdsFromModel = databaseModelTypeIds.Except(entityModelTypeIds).ToList();
        //
        // foreach (var typeId in removedTypeIdsFromModel)
        // {
        //     var removedModelType = databaseVehicleModel.VehicleType.First(type => type.Id.Equals(typeId));
        //     databaseVehicleModel.VehicleType.Remove(removedModelType);
        // }
    }
}