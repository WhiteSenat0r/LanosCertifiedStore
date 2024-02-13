using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleModelRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleModel, VehicleModelDataModel>(mapper, dbContext)
{
    public override async Task<List<VehicleModel>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehicleModel entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehicleModel updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehicleModel removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}