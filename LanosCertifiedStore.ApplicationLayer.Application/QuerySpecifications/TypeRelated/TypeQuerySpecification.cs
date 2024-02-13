using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.TypeRelated;

public class TypeQuerySpecification : QuerySpecification<VehicleType>
{
    public TypeQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(t => t.Vehicles);
    }
}