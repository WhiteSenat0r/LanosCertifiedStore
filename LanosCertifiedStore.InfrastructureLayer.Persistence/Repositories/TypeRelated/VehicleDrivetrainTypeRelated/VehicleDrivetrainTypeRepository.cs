using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated;

internal class VehicleDrivetrainTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleDrivetrainTypeSelectionProfile,
        VehicleDrivetrainType,
        VehicleDrivetrainTypeEntity,
        IVehicleDrivetrainTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleDrivetrainType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters = null!)
    {
        var vehicleDrivetrainTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleDrivetrainTypeModels = await vehicleDrivetrainTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleDrivetrainTypeEntity>, IReadOnlyList<VehicleDrivetrainType>>(
            vehicleDrivetrainTypeModels);
    }

    public override async Task<VehicleDrivetrainType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleDrivetrainTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleDrivetrainTypeEntity>(), new VehicleDrivetrainTypeFilteringRequestParameters());

        var vehicleDrivetrainTypeModel = await vehicleDrivetrainTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleDrivetrainTypeModel is not null 
            ? Mapper.Map<VehicleDrivetrainTypeEntity, VehicleDrivetrainType>(vehicleDrivetrainTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleDrivetrainTypeEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleDrivetrainTypeEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleDrivetrainTypeEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleDrivetrainTypeSelectionProfile,
            VehicleDrivetrainType,
            VehicleDrivetrainTypeEntity,
            IVehicleDrivetrainTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleDrivetrainTypeQueryBuilder(
            new VehicleDrivetrainTypeSelectionProfiles(), new VehicleDrivetrainTypeFilteringCriteria());
}