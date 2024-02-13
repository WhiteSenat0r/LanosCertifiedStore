using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.DisplacementRelated;

public sealed class DisplacementQuerySpecification : QuerySpecification<VehicleDisplacement>
{
    public DisplacementQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(d => d.Vehicles);
    }
}