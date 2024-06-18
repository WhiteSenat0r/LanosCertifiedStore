namespace Persistence.Repositories.IdentityRelated;

// TODO Add implementation
// internal class UserRepository(IMapper mapper, ApplicationDatabaseContext dbContext)
//     : GenericRepository<User, UserDataModel>(mapper, dbContext)
// {
//     public override async Task<IReadOnlyList<User>> GetAllEntitiesAsync(
//         IFilteringRequestParameters<User>? filteringRequestParameters = null)
//     {
//         var userQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
//
//         var userModels = await userQueryEvaluator.GetAllEntitiesQueryable().AsNoTracking().ToListAsync();
//
//         return Mapper.Map<IReadOnlyList<UserDataModel>, IReadOnlyList<User>>(userModels);
//     }
//
//     public override async Task<User?> GetEntityByIdAsync(Guid id)
//     {
//         var userQueryEvaluator = GetQueryEvaluator(null);
//
//         var userQuery = userQueryEvaluator.GetSingleEntityQueryable(id);
//
//         var userModel = await userQuery.AsNoTracking().SingleOrDefaultAsync();
//
//         return userModel is not null
//             ? Mapper.Map<UserDataModel, User>(userModel)
//             : null;
//     }
//
//     public override async Task<int> CountAsync(IFilteringRequestParameters<User>? filteringRequestParameters = null)
//     {
//         var userQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
//
//         var counterQueryable = userQueryEvaluator.GetRelevantCountQueryable();
//
//         return await counterQueryable.CountAsync();
//     }
//
//     private protected override IQueryable<UserDataModel> GetRelevantQueryable(
//         IFilteringRequestParameters<User> filteringRequestParameters)
//     {
//         var vehicleQueryEvaluator = GetQueryEvaluator(filteringRequestParameters);
//
//         return vehicleQueryEvaluator.GetAllEntitiesQueryable();
//     }
//
//     private protected override BaseQueryEvaluator<User, UserDataModel> GetQueryEvaluator(
//         IFilteringRequestParameters<User>? filteringRequestParameters) =>
//         new UserQueryEvaluator(
//             selectionProfiles: UserIncludedAspects.IncludedAspects,
//             filteringRequestParameters: filteringRequestParameters,
//             dataModels: Context.Set<UserDataModel>(),
//             userFilteringCriteria: new UserFilteringCriteria());
// }