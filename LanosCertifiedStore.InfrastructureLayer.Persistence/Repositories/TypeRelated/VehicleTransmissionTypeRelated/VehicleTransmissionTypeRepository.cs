using Application.RequestParams.TypeRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Contracts.RequestParametersRelated.TypeRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Enums.RequestParametersRelated.TypeRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated.TypeRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated;

internal class VehicleTransmissionTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeDataModel,
        IVehicleTransmissionTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleTransmissionType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null!)
    {
        var vehicleTransmissionTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTransmissionTypeModels = await vehicleTransmissionTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleTransmissionTypeDataModel>, IReadOnlyList<VehicleTransmissionType>>
            (vehicleTransmissionTypeModels);
    }

    public override async Task<VehicleTransmissionType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTransmissionTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, 
            Context.Set<VehicleTransmissionTypeDataModel>(),
            new VehicleTransmissionTypeFilteringRequestParameters());

        var vehicleTransmissionTypeModel = await vehicleTransmissionTypeModelQuery
            .AsNoTracking()
            .SingleOrDefaultAsync();
        
        return vehicleTransmissionTypeModel is not null 
            ? Mapper.Map<VehicleTransmissionTypeDataModel, VehicleTransmissionType>(vehicleTransmissionTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleTransmissionTypeDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleTransmissionTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleTransmissionTypeDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleTransmissionTypeSelectionProfile,
            VehicleTransmissionType,
            VehicleTransmissionTypeDataModel,
            IVehicleTransmissionTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleTransmissionTypeQueryBuilder(
            new VehicleTransmissionTypeSelectionProfiles(), new VehicleTransmissionTypeFilteringCriteria());
}