namespace Persistence.Repositories.VehiclePriceRelated;

// TODO
// internal class VehiclePriceRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehiclePriceSelectionProfile,
//         VehiclePrice,
//         VehiclePrice,
//         IVehiclePriceFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehiclePrice>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null!)
//     {
//         var vehiclePriceQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehiclePrices = await vehiclePriceQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehiclePrice>, IReadOnlyList<VehiclePrice>>(vehiclePrices);
//     }
//
//     public override async Task<VehiclePrice?> GetEntityByIdAsync(Guid id)
//     {
//         var vehiclePriceQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, Context.Set<VehiclePrice>(), new VehiclePriceFilteringRequestParameters
//             {
//                 ProjectionProfile = VehiclePriceSelectionProfile.Full
//             });
//
//         var vehiclePrice = await vehiclePriceQuery.AsNoTracking().SingleOrDefaultAsync();
//         
//         return vehiclePrice is not null 
//             ? Mapper.Map<VehiclePrice, VehiclePrice>(vehiclePrice) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehiclePrice>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehiclePrice> GetRelevantQueryable(
//         IFilteringRequestParameters<VehiclePrice>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehiclePrice>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehiclePriceSelectionProfile,
//             VehiclePrice,
//             VehiclePrice,
//             IVehiclePriceFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehiclePriceQueryBuilder(new VehiclePriceSelectionProfiles(), new VehiclePriceFilteringCriteria());
// }