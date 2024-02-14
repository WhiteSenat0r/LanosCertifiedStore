using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehiclePriceRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehiclePrice, VehiclePriceDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehiclePrice> filteringRequestParameters = null!)
    {
        throw new NotImplementedException();
    }

    public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    private protected override async Task<IQueryable<VehiclePriceDataModel>> HandleQueryFiltering(
        DbSet<VehiclePriceDataModel> dbSet, IFilteringRequestParameters<VehiclePrice> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}