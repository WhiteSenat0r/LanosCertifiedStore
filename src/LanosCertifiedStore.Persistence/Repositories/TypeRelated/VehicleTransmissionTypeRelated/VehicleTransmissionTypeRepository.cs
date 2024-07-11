namespace Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated;

// TODO
// internal class VehicleTransmissionTypeRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<VehicleTransmissionTypeSelectionProfile,
//         VehicleTransmissionType,
//         VehicleTransmissionType,
//         IVehicleTransmissionTypeFilteringRequestParameters>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<VehicleTransmissionType>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null!)
//     {
//         var vehicleTransmissionTypeModelsQuery = GetRelevantQueryable(filteringRequestParameters);
//
//         var vehicleTransmissionTypeModels = await vehicleTransmissionTypeModelsQuery.AsNoTracking().ToListAsync();
//         
//         return Mapper.Map<IReadOnlyList<VehicleTransmissionType>, IReadOnlyList<VehicleTransmissionType>>
//             (vehicleTransmissionTypeModels);
//     }
//
//     public override async Task<VehicleTransmissionType?> GetEntityByIdAsync(Guid id)
//     {
//         var vehicleTransmissionTypeModelQuery = QueryBuilder.GetSingleEntityQueryable(
//             id, 
//             Context.Set<VehicleTransmissionType>(),
//             new VehicleTransmissionTypeFilteringRequestParameters());
//
//         var vehicleTransmissionTypeModel = await vehicleTransmissionTypeModelQuery
//             .AsNoTracking()
//             .SingleOrDefaultAsync();
//         
//         return vehicleTransmissionTypeModel is not null 
//             ? Mapper.Map<VehicleTransmissionType, VehicleTransmissionType>(vehicleTransmissionTypeModel) 
//             : null;
//     }
//
//     public override Task<int> CountAsync(
//         IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters = null)
//     {
//         var countedQueryable = QueryBuilder.GetRelevantCountQueryable(
//             Context.Set<VehicleTransmissionType>(), filteringRequestParameters);
//
//         return countedQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<VehicleTransmissionType> GetRelevantQueryable(
//         IFilteringRequestParameters<VehicleTransmissionType>? filteringRequestParameters) =>
//         QueryBuilder.GetAllEntitiesQueryable(
//             Context.Set<VehicleTransmissionType>(), filteringRequestParameters);
//
//     private protected override BaseQueryBuilder<VehicleTransmissionTypeSelectionProfile,
//             VehicleTransmissionType,
//             VehicleTransmissionType,
//             IVehicleTransmissionTypeFilteringRequestParameters>
//         GetQueryBuilder() =>
//         new VehicleTransmissionTypeQueryBuilder(
//             new VehicleTransmissionTypeSelectionProfiles(), new VehicleTransmissionTypeFilteringCriteria());
// }