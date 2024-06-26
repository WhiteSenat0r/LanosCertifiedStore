using Domain.Models.VehicleRelated.Classes;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

internal sealed class CountVehicleBrandsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleBrand, VehicleBrandEntity> filteringCriteriaSelector) : 
    CountQueryBase<VehicleBrand, VehicleBrandEntity>(context, filteringCriteriaSelector);