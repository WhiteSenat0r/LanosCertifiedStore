using System.Linq.Expressions;
using Persistence.DataModels;

namespace Persistence.Repositories.VehicleRelated.QueryEvaluationRelated.Common.Classes;

internal abstract class VehicleIncludedAspects
{
    public static readonly List<Expression<Func<VehicleDataModel, object>>> IncludedAspects =
    [
        vehicle => vehicle.Brand,
        vehicle => vehicle.Model,
        vehicle => vehicle.Type,
        vehicle => vehicle.Displacement,
        vehicle => vehicle.Color,
        vehicle => vehicle.Prices
    ];
}