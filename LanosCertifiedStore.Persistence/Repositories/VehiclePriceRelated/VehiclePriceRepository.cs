namespace Persistence.Repositories.VehiclePriceRelated;

// TODO
// internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehiclePriceSelectionProfile,
//         VehiclePrice,
//         VehiclePriceEntity,
//         IVehiclePriceFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null!)
//     {
//         var vehiclePriceQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehiclePrices = await vehiclePriceQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehiclePriceEntity>, IReadOnlyList<VehiclePrice>>(vehiclePrices);
//     }
//
//     public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
//     {
//         var vehiclePriceQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehiclePriceEntity>(), new VehiclePriceFilteringRequestParameters
//             {
//                 SelectionProfile = VehiclePriceSelectionProfile.Full
//             });
//
//         var vehiclePrice = await vehiclePriceQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehiclePrice is not null 
//             ? Mapper.Map<VehiclePriceEntity, VehiclePrice>(vehiclePrice) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehiclePriceEntity>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehiclePriceEntity> GetRelevantQueryable(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehiclePriceEntity>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehiclePriceSelectionProfile,
//             VehiclePrice,
//             VehiclePriceEntity,
//             IVehiclePriceFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehiclePriceQueryBuilder(new VehiclePriceSelectionProfiles(), new VehiclePriceFilteringCriteria());
// }