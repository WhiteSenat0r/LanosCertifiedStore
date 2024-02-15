using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleSortingTypes
{
    public static readonly Dictionary<string, Expression<Func<VehicleDataModel, object>>> 
        Options = new()
    {
        { "brand-desc", vehicle => vehicle.Brand.Name },
        { "price-asc", vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault()!.Value },
        { "price-desc", vehicle => vehicle.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault()!.Value },
        { "brand-asc", vehicle => vehicle.Brand.Name },
        { "default", vehicle => vehicle.Brand.Name }
    };
}