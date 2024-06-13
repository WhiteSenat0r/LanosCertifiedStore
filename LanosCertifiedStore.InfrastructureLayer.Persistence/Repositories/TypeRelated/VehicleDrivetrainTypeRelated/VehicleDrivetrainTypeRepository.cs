using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated.TypeRelated;
using Application.Enums.RequestParametersRelated.TypeRelated;
using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated;

internal class VehicleDrivetrainTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleDrivetrainTypeSelectionProfile,
        VehicleDrivetrainType,
        VehicleDrivetrainTypeDataModel,
        IVehicleDrivetrainTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleDrivetrainType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters = null!)
    {
        var vehicleDrivetrainTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleDrivetrainTypeModels = await vehicleDrivetrainTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleDrivetrainTypeDataModel>, IReadOnlyList<VehicleDrivetrainType>>(
            vehicleDrivetrainTypeModels);
    }

    public override async Task<VehicleDrivetrainType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleDrivetrainTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleDrivetrainTypeDataModel>(), new VehicleDrivetrainTypeFilteringRequestParameters());

        var vehicleDrivetrainTypeModel = await vehicleDrivetrainTypeModelQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleDrivetrainTypeModel is not null 
            ? Mapper.Map<VehicleDrivetrainTypeDataModel, VehicleDrivetrainType>(vehicleDrivetrainTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleDrivetrainTypeDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleDrivetrainTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleDrivetrainType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleDrivetrainTypeDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleDrivetrainTypeSelectionProfile,
            VehicleDrivetrainType,
            VehicleDrivetrainTypeDataModel,
            IVehicleDrivetrainTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleDrivetrainTypeQueryBuilder(
            new VehicleDrivetrainTypeSelectionProfiles(), new VehicleDrivetrainTypeFilteringCriteria());
}