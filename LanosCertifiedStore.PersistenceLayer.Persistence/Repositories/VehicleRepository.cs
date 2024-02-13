using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<Vehicle, VehicleDataModel>(mapper, dbContext)
{
    public override async Task<List<Vehicle>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<Vehicle?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(Vehicle entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(Vehicle updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(Vehicle removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}