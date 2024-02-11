using System.Linq.Expressions;
using Application.QuerySpecifications.Common.Classes;
using Application.RequestParams;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.VehiclesRelated;

public sealed class VehicleQuerySpecification : BaseQuerySpecification<Vehicle>
{
    public VehicleQuerySpecification(VehicleRequestParameters requestParameters) : base(requestParameters)
    {
        AddIncludes();
        Criteria = GetVehicleFilteringCriteria(requestParameters);
        DeterminateSortingType(requestParameters);
    }

    private Expression<Func<Vehicle, bool>> GetVehicleFilteringCriteria(
        VehicleRequestParameters requestParameters) =>
        vehicle => 
            (string.IsNullOrEmpty(requestParameters.Brand) ||
             vehicle.Brand.Name.Equals(requestParameters.Brand)) &&
            (string.IsNullOrEmpty(requestParameters.Type) ||
             vehicle.Type.Name.Equals(requestParameters.Type)) &&
            (string.IsNullOrEmpty(requestParameters.Color) ||
             vehicle.Color.Name.Equals(requestParameters.Color)) &&
            (!requestParameters.Displacement.HasValue ||
             vehicle.Displacement.Value.Equals(requestParameters.Displacement)) &&
            (!requestParameters.LowerPriceLimit.HasValue || 
             vehicle.Prices.MaxBy(p => p.IssueDate).Value >= requestParameters.LowerPriceLimit 
             && vehicle.Prices.MaxBy(
                 p => p.IssueDate).IssueDate.Date >= requestParameters.MinimalPriceDate.Value) &&
            (!requestParameters.LowerPriceLimit.HasValue || 
             vehicle.Prices.MaxBy(p => p.IssueDate).Value <= requestParameters.UpperPriceLimit
             && vehicle.Prices.MaxBy(
                 p => p.IssueDate).IssueDate.Date >= requestParameters.MinimalPriceDate.Value);

    private void AddIncludes()
    {
        AddInclude(v => v.Brand);
        AddInclude(v => v.Model);
        AddInclude(v => v.Displacement);
        AddInclude(v => v.Color);
        AddInclude(v => v.Type);
        AddInclude(v => v.Prices);
    }

    private protected override void DeterminateSortingType(IRequestParameters requestParameters)
    {
        switch (requestParameters.SortingType)
        {
            case "brand-desc":
                AddOrderByDescending(v => v.Brand.Name);
                break;
            case "price-asc":
                AddOrderByAscending(v =>
                    v.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault().Value);
                break;
            case "price-desc":
                AddOrderByDescending(v =>
                    v.Prices.OrderByDescending(p => p.IssueDate).FirstOrDefault().Value);
                break;
            case "brand-asc":
                AddOrderByAscending(v => v.Brand.Name);
                break;
            default:
                AddOrderByAscending(v => v.Brand.Name);
                break;
        }
    }
}