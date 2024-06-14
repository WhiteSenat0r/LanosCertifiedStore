using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated;

internal class VehicleImageRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleImageSelectionProfile,
        VehicleImage,
        VehicleImageEntity, 
        IVehicleImageFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleImage>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null!)
    {
        var vehicleImagesQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleImages = await vehicleImagesQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleImageEntity>, IReadOnlyList<VehicleImage>>(vehicleImages);
    }

    public override async Task<VehicleImage?> GetEntityByIdAsync(Guid id)
    {
        var vehicleImageQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleImageEntity>(), new VehicleImageFilteringRequestParameters());

        var vehicleImageModel = await vehicleImageQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleImageModel is not null 
            ? Mapper.Map<VehicleImageEntity, VehicleImage>(vehicleImageModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleImageEntity>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleImageEntity> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleImageEntity>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleImageSelectionProfile,
            VehicleImage,
            VehicleImageEntity,
            IVehicleImageFilteringRequestParameters> 
        GetQueryBuilder() =>
        new VehicleImageQueryBuilder(new VehicleImageSelectionProfiles(), new VehicleImageFilteringCriteria());
}