namespace Persistence.Repositories.VehicleColorRelated;

// TODO
// internal class VehicleColorRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleColorSelectionProfile,
//         VehicleColor,
//         VehicleColorEntity,
//         IVehicleColorFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleColor>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null!)
//     {
//         var vehicleColorsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleColors = await vehicleColorsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleColorEntity>, IReadOnlyList<VehicleColor>>(vehicleColors);
//     }
//
//     public override async Task<VehicleColor?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleColorQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehicleColorEntity>(), new VehicleColorFilteringRequestParameters());
//
//         var vehicleColorModel = await vehicleColorQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehicleColorModel is not null 
//             ? Mapper.Map<VehicleColorEntity, VehicleColor>(vehicleColorModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleColor>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleColorEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleColorEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleColor>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleColorEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleColorSelectionProfile,
//             VehicleColor,
//             VehicleColorEntity,
//             IVehicleColorFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleColorQueryBuilder(
//             new VehicleColorSelectionProfiles(),
//             new VehicleColorFilteringCriteria());
// }