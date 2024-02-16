using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.Contexts;
using Persistence.DataModels;
using Persistence.Repositories.Common.Classes;

namespace Persistence.Repositories;

internal class VehicleModelRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleModel, VehicleModelDataModel>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleModel>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null!)
    {
        throw new NotImplementedException();
    }

    public override async Task<VehicleModel?> GetEntityByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> CountAsync(
        IFilteringRequestParameters<VehicleModel>? filteringRequestParameters = null)
    {
        throw new NotImplementedException();
    }

    private protected override IQueryable<VehicleModelDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleModel> filteringRequestParameters)
    {
        throw new NotImplementedException();
    }
}