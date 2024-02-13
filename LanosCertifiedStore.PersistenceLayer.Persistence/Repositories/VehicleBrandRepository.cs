using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleBrand, VehicleBrandDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleBrand>> GetAllEntitiesAsync()
    {
        var brandModels = await dbContext.VehiclesBrands
            .Include(x => x.Models)
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IReadOnlyList<VehicleBrandDataModel>, IReadOnlyList<VehicleBrand>>(brandModels);
    }

    public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
    {
        var brandModel = await dbContext.VehiclesBrands
            .Include(x => x.Models)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);

        return brandModel is null ? null : mapper.Map<VehicleBrandDataModel, VehicleBrand>(brandModel);
    }

    public override async Task AddNewEntityAsync(VehicleBrand entity)
    {
        var brandModel = mapper.Map<VehicleBrand, VehicleBrandDataModel>(entity);

        await dbContext.VehiclesBrands.AddAsync(brandModel);
    }

    public override void UpdateExistingEntity(VehicleBrand updatedEntity)
    {
        var brandModel = mapper.Map<VehicleBrand, VehicleBrandDataModel>(updatedEntity);

        dbContext.Update(brandModel);
    }

    public override void RemoveExistingEntity(VehicleBrand removedEntity) // TODO maybe pass id here???
    {
        var brandModel = mapper.Map<VehicleBrand, VehicleBrandDataModel>(removedEntity);

        dbContext.VehiclesBrands.Remove(brandModel);
    }

    public override async Task<int> CountAsync()
    {
        return await dbContext.VehiclesBrands.CountAsync();
    }
}