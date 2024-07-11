namespace Persistence.Repositories.VehicleBrandRelated;

// TODO
// internal sealed class VehicleBrandRepository(IMapper mapper, ApplicationDatabaseContext dbContext) :
//     GenericRepository<VehicleBrandProjectionProfile,
//         VehicleBrand,
//         VehicleBrandEntity,
//         IVehicleBrandFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleBrand>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null!)
//     {
//         var vehicleBrandsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleBrands = await vehicleBrandsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleBrandEntity>, IReadOnlyList<VehicleBrand>>(vehicleBrands);
//     }
//
//     public override async Task<VehicleBrand?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleBrandQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleBrandEntity>(), new VehicleBrandFilteringRequestParameters
//         {
//             ProjectionProfile = VehicleBrandProjectionProfile.Single
//         });
//
//         var vehicleBrandModel = await vehicleBrandQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleBrandModel is not null 
//             ? Mapper.Map<VehicleBrandEntity, VehicleBrand>(vehicleBrandModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleBrandEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleBrandEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleBrand>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleBrandEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleBrandProjectionProfile,
//         VehicleBrand,
//         VehicleBrandEntity, 
//         IVehicleBrandFilteringRequestParameters> GetQueryBuilder() =>
//         new VehicleBrandQueryBuilder(
//             new VehicleBrandSelectionProfiles(),
//             new VehicleBrandFilteringCriteria());
// }