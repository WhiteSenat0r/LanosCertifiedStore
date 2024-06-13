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
using Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated;

internal class VehicleBodyTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleBodyTypeSelectionProfile,
        VehicleBodyType,
        VehicleBodyTypeDataModel,
        IVehicleBodyTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleBodyType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters = null!)
    {
        var vehicleBodyTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleBodyTypeModels = await vehicleBodyTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleBodyTypeDataModel>, IReadOnlyList<VehicleBodyType>>(vehicleBodyTypeModels);
    }

    public override async Task<VehicleBodyType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleBodyTypeModelsQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleBodyTypeDataModel>(), new VehicleBodyTypeFilteringRequestParameters());

        var vehicleBodyTypeModel = await vehicleBodyTypeModelsQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleBodyTypeModel is not null 
            ? Mapper.Map<VehicleBodyTypeDataModel, VehicleBodyType>(vehicleBodyTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleBodyTypeDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleBodyTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBodyType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleBodyTypeDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleBodyTypeSelectionProfile,
            VehicleBodyType,
            VehicleBodyTypeDataModel,
            IVehicleBodyTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleBodyTypeQueryBuilder(new VehicleBodyTypeSelectionProfiles(), new VehicleBodyTypeFilteringCriteria());
}