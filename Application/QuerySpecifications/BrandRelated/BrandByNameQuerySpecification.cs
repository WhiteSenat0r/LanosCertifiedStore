using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.BrandRelated;

public sealed class BrandByNameQuerySpecification
    : QuerySpecification<VehicleBrand>
{
    public BrandByNameQuerySpecification(string name, bool isNotTracked = false) 
        : base(b => b.Name.Equals(name))
    {
        IsNotTracked = isNotTracked;
        AddInclude(b => b.Models);
    }
}