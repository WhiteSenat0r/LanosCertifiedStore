using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehiclePriceRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehiclePriceRelated;

internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehiclePriceSelectionProfile, VehiclePrice, VehiclePriceDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null!)
    {
        var vehiclePriceQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehiclePrices = await vehiclePriceQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehiclePriceDataModel>, IReadOnlyList<VehiclePrice>>(vehiclePrices);
    }

    public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
    {
        var vehiclePriceQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehiclePriceDataModel>(), new VehiclePriceFilteringRequestParameters
            {
                SelectionProfile = VehiclePriceSelectionProfile.Full
            });

        var vehiclePrice = await vehiclePriceQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehiclePrice is not null 
            ? Mapper.Map<VehiclePriceDataModel, VehiclePrice>(vehiclePrice) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehiclePriceDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehiclePriceDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehiclePriceDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehiclePriceSelectionProfile, VehiclePrice, VehiclePriceDataModel>
        GetQueryEvaluator() =>
        new VehiclePriceQueryEvaluator(new VehiclePriceSelectionProfiles(), new VehiclePriceFilteringCriteria());
}