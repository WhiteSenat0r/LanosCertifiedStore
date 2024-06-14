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
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated;

internal class VehicleTransmissionTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleTransmissionTypeSelectionProfile,
        VehicleTransmissionType,
        VehicleTransmissionTypeEntity,
        IVehicleTransmissionTypeFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleTransmissionType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null!)
    {
        var vehicleTransmissionTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleTransmissionTypeModels = await vehicleTransmissionTypeModelsQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleTransmissionTypeEntity>, IReadOnlyList<VehicleTransmissionType>>
            (vehicleTransmissionTypeModels);
    }

    public override async Task<VehicleTransmissionType?> GetEntityByIdAsync(Guid id)
    {
        var vehicleTransmissionTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
            id, 
            Context.Set<VehicleTransmissionTypeEntity>(),
            new VehicleTransmissionTypeFilteringRequestParameters());

        var vehicleTransmissionTypeModel = await vehicleTransmissionTypeModelQuery
            .AsNoTracking()
            .SingleOrDefaultAsync();
        
        return vehicleTransmissionTypeModel is not null 
            ? Mapper.Map<VehicleTransmissionTypeEntity, VehicleTransmissionType>(vehicleTransmissionTypeModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleTransmissionTypeEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleTransmissionTypeEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleTransmissionTypeEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleTransmissionTypeSelectionProfile,
            VehicleTransmissionType,
            VehicleTransmissionTypeEntity,
            IVehicleTransmissionTypeFilteringRequestParameters>
        GetQueryBuilder() =>
        new VehicleTransmissionTypeQueryBuilder(
            new VehicleTransmissionTypeSelectionProfiles(), new VehicleTransmissionTypeFilteringCriteria());
}