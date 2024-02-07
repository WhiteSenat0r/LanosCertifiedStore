using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.BrandRelated;

public sealed class BrandQuerySpecification : QuerySpecification<VehicleBrand>
{
    public BrandQuerySpecification(string name) : base(x => x.Name.Contains(name))
    {
    }

    public BrandQuerySpecification()
    {
    }
}