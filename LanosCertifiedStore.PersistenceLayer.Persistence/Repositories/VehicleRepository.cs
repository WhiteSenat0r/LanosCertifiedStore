using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<Vehicle, VehicleDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync(
        IFilteringRequestParameters<Vehicle> filteringRequestParameters = null!)
    {
        var vehicleModels = await Context.Set<VehicleDataModel>()
            .Include(x => x.Model)
            .Include(x => x.Brand)
            .Include(x => x.Displacement)
            .Include(x => x.Color)
            .Include(x => x.Type)
            .Include(x => x.Prices)
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleDataModel>, IReadOnlyList<Vehicle>>(vehicleModels);
    }

    public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    private protected override async Task<IQueryable<VehicleDataModel>> HandleQueryFiltering(
        DbSet<VehicleDataModel> dbSet, IFilteringRequestParameters<Vehicle> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}