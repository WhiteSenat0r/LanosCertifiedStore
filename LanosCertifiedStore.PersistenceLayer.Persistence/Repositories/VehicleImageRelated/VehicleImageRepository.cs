using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated;

internal class VehicleImageRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleImage, VehicleImageDataModel>(mapper, dbContext)
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
        var vehicleImagesQueryEvaluator = GetQueryEvaluator(null);

        var vehicleImageQuery = vehicleImagesQueryEvaluator.GetSingleEntityQueryable(id);

        var vehicleImageModel = await vehicleImageQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleImageModel is not null 
            ? Mapper.Map<VehicleImageDataModel, VehicleImage>(vehicleImageModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null)
    {
        var vehicleImagesQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
        
        var countedQueryable = vehicleImagesQueryEvaluator.GetRelevantCountQueryable();

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleImageDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters)
    {
        var vehicleImagesQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);

        return vehicleImagesQueryEvaluator.GetAllEntitiesQueryable();
    }

    private protected override BaseQueryEvaluator<VehicleImage, VehicleImageDataModel> GetQueryEvaluator(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
        new VehicleImageQueryEvaluator(
            includedAspects: VehicleImageIncludedAspects.IncludedAspects,
            filteringRequestParameters: filteringRequestParameters,
            dataModels: Context.Set<VehicleImageDataModel>(),
            imageFilteringCriteria: new VehicleImageFilteringCriteria());
}