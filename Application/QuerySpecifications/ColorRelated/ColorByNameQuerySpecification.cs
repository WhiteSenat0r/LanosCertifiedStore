using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ColorRelated;

public sealed class ColorByNameQuerySpecification : QuerySpecification<VehicleColor>
{
    public ColorByNameQuerySpecification(string name, bool isNotTracked = false) 
        : base(c => c.Name.Equals(name))
    {
        IsNotTracked = isNotTracked;
        AddInclude(c => c.Vehicles);
    }
}