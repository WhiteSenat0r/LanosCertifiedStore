using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleColor, VehicleColorDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleColor>> GetAllEntitiesAsync()
    {
        var colorModels = await dbContext.VehiclesColors
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleColorDataModel>, IReadOnlyList<VehicleColor>>(colorModels);
    }

    public override async Task<VehicleColor?> GetEntityByIdAsync(Guid id)
    {
        var colorModel = await dbContext.VehiclesColors
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return colorModel is null ? null : mapper.Map<VehicleColorDataModel, VehicleColor>(colorModel);
    }

    public override async Task AddNewEntityAsync(VehicleColor entity)
    {
        var colorModel = mapper.Map<VehicleColor, VehicleColorDataModel>(entity);

        await dbContext.VehiclesColors.AddAsync(colorModel);
    }

    public override void UpdateExistingEntity(VehicleColor updatedEntity)
    {
        var colorModel = mapper.Map<VehicleColor, VehicleColorDataModel>(updatedEntity);

        dbContext.VehiclesColors.Update(colorModel);
    }

    public override void RemoveExistingEntity(VehicleColor removedEntity) // TODO same here: maybe id????
    {
        var colorModel = mapper.Map<VehicleColor, VehicleColorDataModel>(removedEntity);

        dbContext.VehiclesColors.Remove(colorModel);
    }

    public override async Task<int> CountAsync()
    {
        return await dbContext.VehiclesColors.CountAsync();
    }
}