using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleType, VehicleTypeDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null!)
    {
        var typeModels = await Context.Set<VehicleTypeDataModel>()
            .Include(model => model.Vehicles)
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyList<VehicleTypeDataModel>, IReadOnlyList<VehicleType>>(typeModels);
    }

    public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
    {
        var typeModel = await Context.Set<VehicleTypeDataModel>()
            .Include(model => model.Vehicles)
            .AsNoTracking()
            .SingleOrDefaultAsync(model => model.Id.Equals(id));

        return typeModel is null 
            ? null
            : Mapper.Map<VehicleTypeDataModel, VehicleType>(typeModel);
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehicleType>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehicleTypeDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleType> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}