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
    public override async Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync()
    {
        var vehicleModels = await Context.Set<VehicleDataModel>()
            .Include(x => x.ModelDataModel)
            .Include(x => x.BrandDataModel)
            .Include(x => x.DisplacementDataModel)
            .Include(x => x.ColorDataModel)
            .Include(x => x.TypeDataModel)
            .Include(x => x.Prices)
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleDataModel>, IReadOnlyList<VehicleModel>>(vehicleModels);
    }

    public override Task<IReadOnlyList<Vehicle>> GetAllEntitiesAsync(
            IFilteringRequestParameters<Vehicle> filteringRequestParameters)
        // TODO implement handling filtering model for query
    {
        var vehicleModelsQuery = Context.Set<VehicleDataModel>()
            .Include(x => x.ModelDataModel)
            .Include(x => x.BrandDataModel)
            .Include(x => x.DisplacementDataModel)
            .Include(x => x.ColorDataModel)
            .Include(x => x.TypeDataModel)
            .Include(x => x.Prices)
            .AsNoTracking();
    }

    public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
    {
        var vehicleModel = await Context.Set<VehicleDataModel>()
            .Include(x => x.ModelDataModel)
            .Include(x => x.BrandDataModel)
            .Include(x => x.DisplacementDataModel)
            .Include(x => x.ColorDataModel)
            .Include(x => x.TypeDataModel)
            .Include(x => x.Prices)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

        return vehicleModel is null ? null : mapper.Map<VehicleDataModel, Vehicle>(vehicleModel);
    }

    public override async Task AddNewEntityAsync(Vehicle entity)
    {
        var vehicleDataModel = mapper.Map<Vehicle, VehicleDataModel>(entity);

        await Context.Set<VehicleDataModel>().AddAsync(vehicleDataModel);
    }

    public override void UpdateExistingEntity(Vehicle updatedEntity)
    {
        var vehicleDataModel = mapper.Map<Vehicle, VehicleDataModel>(updatedEntity);

        Context.Set<VehicleDataModel>().Update(vehicleDataModel);
    }

    public override void RemoveExistingEntity(Vehicle removedEntity)
    {
        var vehicleDataModel = mapper.Map<Vehicle, VehicleDataModel>(removedEntity);

        Context.Set<VehicleDataModel>().Remove(vehicleDataModel);
    }

    public override async Task<int> CountAsync()
    {
        return await Context.Set<VehicleDataModel>().CountAsync();
    }
}