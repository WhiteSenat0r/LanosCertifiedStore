using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleDisplacementRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehicleDisplacement, VehicleDisplacementDataModel>(mapper, dbContext)
{
    public override async Task<List<VehicleDisplacement>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleDisplacement?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehicleDisplacement entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehicleDisplacement updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehicleDisplacement removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}