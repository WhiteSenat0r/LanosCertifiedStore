using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleColorRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleColor, VehicleColorDataModel>(mapper, dbContext)
{
    public override async Task<List<VehicleColor>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleColor?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehicleColor entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehicleColor updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehicleColor removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}