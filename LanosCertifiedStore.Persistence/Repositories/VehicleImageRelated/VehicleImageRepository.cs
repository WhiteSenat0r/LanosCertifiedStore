namespace Persistence.Repositories.VehicleImageRelated;

// TODO
// internal class VehicleImageRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleImageSelectionProfile,
//         VehicleImage,
//         VehicleImage, 
//         IVehicleImageFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleImage>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null!)
//     {
//         var vehicleImagesQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleImages = await vehicleImagesQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleImage>, IReadOnlyList<VehicleImage>>(vehicleImages);
//     }
//
//     public override async Task<VehicleImage?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleImageQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleImage>(), new VehicleImageFilteringRequestParameters());
//
//         var vehicleImageModel = await vehicleImageQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleImageModel is not null 
//             ? Mapper.Map<VehicleImage, VehicleImage>(vehicleImageModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleImage>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleImage>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleImage> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleImage>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleImage>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleImageSelectionProfile,
//             VehicleImage,
//             VehicleImage,
//             IVehicleImageFilteringRequestParameters> 
//         GetQueryBuilder() =>
//         new VehicleImageQueryBuilder(new VehicleImageSelectionProfiles(), new VehicleImageFilteringCriteria());
// }