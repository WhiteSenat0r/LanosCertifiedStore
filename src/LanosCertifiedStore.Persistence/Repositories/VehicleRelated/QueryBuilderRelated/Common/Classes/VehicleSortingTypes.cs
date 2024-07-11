using System.Linq.Expressions;
using Domain.Entities.VehicleRelated;

namespace Persistence.Repositories.VehicleRelated.QueryBuilderRelated.Common.Classes;

internal abstract class VehicleSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<Vehicle, object>>> 
        Options = new()
    {
        { "brand-desc", vehicle => vehicle.Brand.Name },
        { "price-asc", vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault()!.Value },
        { "price-desc", vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault()!.Value },
        { "brand-asc", vehicle => vehicle.Brand.Name },
        { "default", vehicle => vehicle.Brand.Name }
    };
}