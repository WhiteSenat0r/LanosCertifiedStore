using AutoMapper;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehiclePriceRepository(IMapper mapper, DbContext dbContext)
    : GenericRepository<VehiclePrice, VehiclePriceDataModel>(mapper, dbContext)
{
    public override async Task<List<VehiclePrice>> GetAllEntitiesAsync()
    {
        throw new NotImplementedException();
    }

    public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task AddNewEntityAsync(VehiclePrice entity)
    {
        throw new NotImplementedException();
    }

    public override void UpdateExistingEntity(VehiclePrice updatedEntity)
    {
        throw new NotImplementedException();
    }

    public override void RemoveExistingEntity(VehiclePrice removedEntity)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}