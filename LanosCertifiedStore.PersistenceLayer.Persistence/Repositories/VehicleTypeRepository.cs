using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleTypeRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleType, VehicleTypeDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleType>> GetAllEntitiesAsync()
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

    public override async Task AddNewEntityAsync(VehicleType entity)
    {
        var mappedTypeEntity = Mapper.Map<VehicleType, VehicleTypeDataModel>(entity);

        await Context.Set<VehicleTypeDataModel>().AddAsync(mappedTypeEntity);
    }

    public override void UpdateExistingEntity(VehicleType updatedEntity)
    {
        var mappedTypeEntity = Mapper.Map<VehicleType, VehicleTypeDataModel>(updatedEntity);

        Context.Set<VehicleTypeDataModel>().Update(mappedTypeEntity);
    }

    public override void RemoveExistingEntity(VehicleType removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        return await Context.Set<VehicleTypeDataModel>().CountAsync();
    }
}