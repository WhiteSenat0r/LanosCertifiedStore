using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehiclePrice, VehiclePriceDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null!)
    {
        var priceModels = await Context.Set<VehiclePriceDataModel>()
            .Include(p => p.Vehicle)
            .AsNoTracking()
            .ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehiclePriceDataModel>, IReadOnlyList<VehiclePrice>>(priceModels);
    }

    public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
    {
        var priceModel = await Context.Set<VehiclePriceDataModel>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return priceModel is null ? null : Mapper.Map<VehiclePriceDataModel, VehiclePrice>(priceModel);
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehiclePriceDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehiclePrice> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}