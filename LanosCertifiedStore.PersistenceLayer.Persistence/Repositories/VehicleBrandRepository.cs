using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleBrand, VehicleBrandDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleBrand>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null!)
    {
        var brandModels = await Context.Set<VehicleBrandDataModel>()
            .Include(x => x.Models)
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyList<VehicleBrandDataModel>, IReadOnlyList<VehicleBrand>>(brandModels);
    }

    public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
    {
        var brandModel = await Context.Set<VehicleBrandDataModel>()
            .Include(x => x.Models)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return brandModel is null ? null : Mapper.Map<VehicleBrandDataModel, VehicleBrand>(brandModel);
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehicleBrandDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleBrand> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}