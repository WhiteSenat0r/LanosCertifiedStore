using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.VehiclesRelated;

public class VehicleByIdQuerySpecification : QuerySpecification<Vehicle>
{
    public VehicleByIdQuerySpecification(Guid id, bool isNotTracked = false) 
        : base(v => v.Id.Equals(id))
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