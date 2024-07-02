using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class CountVehicleBrandsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleBrand> filteringCriteriaSelector) : 
    CountQueryBase<VehicleBrand>(context, filteringCriteriaSelector);