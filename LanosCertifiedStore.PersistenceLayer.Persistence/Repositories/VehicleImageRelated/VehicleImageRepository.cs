using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Enums.RequestParametersRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels.VehicleRelated;
using Persistence.QueryEvaluation;
using Persistence.Repositories.Common.Classes;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated;
using Persistence.Repositories.VehicleImageRelated.QueryEvaluationRelated.Common.Classes;

namespace Persistence.Repositories.VehicleImageRelated;

internal class VehicleImageRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
    : GenericRepository<VehicleImageSelectionProfile, VehicleImage, VehicleImageDataModel>(mapper, dbContext)
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
        var vehicleImageQuery = QueryEvaluator.GetSingleEntityQueryable(
            id, Context.Set<VehicleImageDataModel>(), new VehicleImageFilteringRequestParameters());

        var vehicleImageModel = await vehicleImageQuery.AsNoTracking().SingleOrDefaultAsync();
        
        return vehicleImageModel is not null 
            ? Mapper.Map<VehicleImageDataModel, VehicleImage>(vehicleImageModel) 
            : null;
    }

    public override Task<int> CountAsync(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null)
    {
        var countedQueryable = QueryEvaluator.GetRelevantCountQueryable(
            Context.Set<VehicleImageDataModel>(), filteringRequestParameters);

        return countedQueryable.CountAsync();
    }

    private protected override IQueryable<VehicleImageDataModel> GetRelevantQueryable(
        IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
        QueryEvaluator.GetAllEntitiesQueryable(
            Context.Set<VehicleImageDataModel>(), filteringRequestParameters);

    private protected override BaseQueryEvaluator<VehicleImageSelectionProfile, VehicleImage, VehicleImageDataModel> 
        GetQueryEvaluator() =>
        new VehicleImageQueryEvaluator(new VehicleImageSelectionProfiles(), new VehicleImageFilteringCriteria());
}