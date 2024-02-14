using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<Vehicle, VehicleDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync(
        IFilteringRequestParameters<Vehicle> filteringRequestParameters = null!)
    {
        throw new NotImplementedException();
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