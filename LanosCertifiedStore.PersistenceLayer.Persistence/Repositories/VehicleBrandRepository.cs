using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleBrandRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleBrand, VehicleBrandDataModel>(mapper, dbContext)
{
    public override async Task<List<VehicleBrand>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehicleBrand entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehicleBrand updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehicleBrand removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}