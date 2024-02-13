using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleTypeRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleType, VehicleTypeDataModel>(mapper, dbContext)
{
    public override async Task<List<VehicleType>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleType?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehicleType entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehicleType updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehicleType removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}