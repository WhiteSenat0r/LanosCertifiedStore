using Application.Contracts.RepositoryRelated.Common;
using Application.Contracts.RequestParametersRelated;
using Application.Enums.RequestParametersRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryBuilder;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated;
using Persistence.Repositories.VehicleImageRelated.QueryBuilderRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated;

internal class VehicleImageRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleImageSelectionProfile,
        VehicleImage,
        VehicleImageDataModel, 
        IVehicleImageFilteringRequestParameters>(mapper, dbContext)
{
    public override async Task<IReadOnlyList<VehicleImage>> GetAllEntitiesAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null!)
    {
        var vehicleImagesQuery = GetRelevantQueryable(filteringRequestParameters);

        var vehicleImages = await vehicleImagesQuery.AsNoTracking().ToListAsync();
        
        return Mapper.Map<IReadOnlyList<VehicleImageDataModel>, IReadOnlyList<VehicleImage>>(vehicleImages);
    }

    public override async Task<VehicleImage?> GetEntityByIdAsync(Guid id)
    {
        var vehicleImageQuery = QueryBuilder.GetSingleEntityQueryable(
            id, Context.Set<VehicleImageDataModel>(), new VehicleImageFilteringRequestParameters());

        var vehicleImageModel = await vehicleImageQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleImageModel is not null 
            ? Mapper.Map<VehicleImageDataModel, VehicleImage>(vehicleImageModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
            Context.Set<VehicleImageDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleImageDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
        QueryBuilder.GetAllEntitiesQueryable(
            Context.Set<VehicleImageDataModel>(), filteringRequestParameters);

    private protected override BaseQueryBuilder<VehicleImageSelectionProfile,
            VehicleImage,
            VehicleImageDataModel,
            IVehicleImageFilteringRequestParameters> 
        GetQueryBuilder() =>
        new VehicleImageQueryBuilder(new VehicleImageSelectionProfiles(), new VehicleImageFilteringCriteria());
}