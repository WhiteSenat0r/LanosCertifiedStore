using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleColor, VehicleColorDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleColor>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null!)
    {
        var colorModels = await Context.Set<VehicleColorDataModel>()
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyList<VehicleColorDataModel>, IReadOnlyList<VehicleColor>>(colorModels);
    }

    public override async Task<VehicleColor?> GetEntityByIdAsync(Guid id)
    {
        var colorModel = await Context.Set<VehicleColorDataModel>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return colorModel is null ? null : Mapper.Map<VehicleColorDataModel, VehicleColor>(colorModel);
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehicleColorDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleColor> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }

    private protected override BaseQueryEvaluator<VehicleColor, VehicleColorDataModel> GetVehicleQueryEvaluator(
        IFilteringRequestParameters<VehicleColor>? filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}