using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ColorRelated;

public sealed class ColorQuerySpecification : QuerySpecification<VehicleColor>
{
    public ColorQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(c => c.Vehicles);
    }
}