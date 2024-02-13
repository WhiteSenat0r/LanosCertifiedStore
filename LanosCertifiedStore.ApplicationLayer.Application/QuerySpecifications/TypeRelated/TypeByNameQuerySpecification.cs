using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.TypeRelated;

public class TypeByNameQuerySpecification : QuerySpecification<VehicleType>
{
    public TypeByNameQuerySpecification(string name, bool isNotTracked = false)
        : base(t => t.Name.Equals(name))
    {
        IsNotTracked = isNotTracked;
        AddInclude(t => t.Vehicles);
    }
}