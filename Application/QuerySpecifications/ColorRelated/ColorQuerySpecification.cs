using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ColorRelated;

public sealed class ColorQuerySpecification : QuerySpecification<VehicleColor>
{
    public ColorQuerySpecification(string name) : base(x => x.Name.Equals(name))
    {
    }

    public ColorQuerySpecification()
    {
    }
}