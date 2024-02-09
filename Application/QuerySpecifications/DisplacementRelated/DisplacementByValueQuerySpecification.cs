using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.DisplacementRelated;

public sealed class DisplacementByValueQuerySpecification : QuerySpecification<VehicleDisplacement>
{
    public DisplacementByValueQuerySpecification(double value, bool isNotTracked = false) 
        : base(m => m.Value.Equals(value))
    {
        IsNotTracked = isNotTracked;
        AddInclude(d => d.Vehicles);
    }
}