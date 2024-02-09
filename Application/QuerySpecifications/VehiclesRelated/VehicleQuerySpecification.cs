using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.VehiclesRelated;

public class VehicleQuerySpecification : QuerySpecification<Vehicle>
{
    public VehicleQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(v => v.Brand);
        AddInclude(v => v.Model);
        AddInclude(v => v.Displacement);
        AddInclude(v => v.Color);
        AddInclude(v => v.Type);
        AddInclude(v => v.Prices);
    }
}