using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleDisplacementRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleDisplacement, VehicleDisplacementDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleDisplacement>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleDisplacement>? filteringRequestParameters = null!)
    {
        var displacementModels = await Context.Set<VehicleDisplacementDataModel>()
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyList<VehicleDisplacementDataModel>, IReadOnlyList<VehicleDisplacement>>(
            displacementModels);
    }

    public override async Task<VehicleDisplacement?> GetEntityByIdAsync(Guid id)
    {
        var displacementModel = await Context.Set<VehicleDisplacementDataModel>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return displacementModel is null
            ? null
            : Mapper.Map<VehicleDisplacementDataModel, VehicleDisplacement>(displacementModel);
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehicleDisplacement>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehicleDisplacementDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleDisplacement> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }

    private protected override BaseQueryEvaluator<VehicleDisplacement, VehicleDisplacementDataModel> GetVehicleQueryEvaluator(
        IFilteringRequestParameters<VehicleDisplacement>? filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}