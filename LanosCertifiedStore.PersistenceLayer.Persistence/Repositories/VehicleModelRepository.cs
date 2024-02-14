using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleModelRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleModel, VehicleModelDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync()
    {
        var vehicleModelDataModels = await Context.Set<VehicleModelDataModel>()
            .Include(x => x.VehicleBrandDataModel)
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleModelDataModel>, IReadOnlyList<VehicleModel>>(vehicleModelDataModels);
    }

    public override Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleModel> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        var vehicleModelDataModel = await Context.Set<VehicleModelDataModel>()
            .Include(x => x.VehicleBrandDataModel)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

        return vehicleModelDataModel is null
            ? null
            : mapper.Map<VehicleModelDataModel, VehicleModel>(vehicleModelDataModel);
    }

    public override async Task AddNewEntityAsync(VehicleModel entity)
    {
        var vehicleModelDataModel = mapper.Map<VehicleModel, VehicleModelDataModel>(entity);

        await Context.Set<VehicleModelDataModel>().AddAsync(vehicleModelDataModel);
    }

    public override void UpdateExistingEntity(VehicleModel updatedEntity)
    {
        var vehicleModelDataModel = mapper.Map<VehicleModel, VehicleModelDataModel>(updatedEntity);

        Context.Set<VehicleModelDataModel>().Update(vehicleModelDataModel);
    }

    public override void RemoveExistingEntity(VehicleModel removedEntity)
    {
        var vehicleModelDataModel = mapper.Map<VehicleModel, VehicleModelDataModel>(removedEntity);

        Context.Set<VehicleModelDataModel>().Remove(vehicleModelDataModel);

    }

    public override async Task<int> CountAsync()
    {
        return await Context.Set<VehicleModelDataModel>().CountAsync();
    }
}