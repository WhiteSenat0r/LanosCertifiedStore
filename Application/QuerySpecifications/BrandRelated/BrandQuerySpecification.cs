using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.BrandRelated;

public sealed class BrandQuerySpecification : QuerySpecification<VehicleBrand>
{
    public BrandQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(b => b.Models);
    }
}