using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleColorRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleColor, VehicleColorDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleColor>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleColor> filteringRequestParameters = null!)
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

    private protected override async Task<IQueryable<VehicleColorDataModel>> HandleQueryFiltering(
        DbSet<VehicleColorDataModel> dbSet, IFilteringRequestParameters<VehicleColor> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}