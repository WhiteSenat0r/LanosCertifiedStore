using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleDisplacementRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleDisplacement, VehicleDisplacementDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleDisplacement>> GetAllEntitiesAsync()
    {
        var displacementModels = await dbContext.VehicleDisplacements
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleDisplacementDataModel>, IReadOnlyList<VehicleDisplacement>>(
            displacementModels);
    }

    public override async Task<VehicleDisplacement?> GetEntityByIdAsync(Guid id)
    {
        var displacementModel = await dbContext.VehicleDisplacements
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return displacementModel is null
            ? null
            : mapper.Map<VehicleDisplacementDataModel, VehicleDisplacement>(displacementModel);
    }

    public override async Task AddNewEntityAsync(VehicleDisplacement entity)
    {
        var displacementModel = mapper.Map<VehicleDisplacement, VehicleDisplacementDataModel>(entity);

        await dbContext.VehicleDisplacements.AddAsync(displacementModel);
    }

    public override void UpdateExistingEntity(VehicleDisplacement updatedEntity)
    {
        var displacementModel = mapper.Map<VehicleDisplacement, VehicleDisplacementDataModel>(updatedEntity);

        dbContext.VehicleDisplacements.Update(displacementModel);

    }

    public override void RemoveExistingEntity(VehicleDisplacement removedEntity) // TODO idk about id anymore
    {
        var displacementModel = mapper.Map<VehicleDisplacement, VehicleDisplacementDataModel>(removedEntity);

        dbContext.VehicleDisplacements.Remove(displacementModel); 
    }

    public override async Task<int> CountAsync()
    {
        return await dbContext.VehicleDisplacements.CountAsync();
    }
}