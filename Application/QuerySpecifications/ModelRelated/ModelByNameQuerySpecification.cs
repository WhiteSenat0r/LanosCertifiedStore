using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ModelRelated;

public sealed class ModelByNameQuerySpecification : QuerySpecification<VehicleModel>
{
    public ModelByNameQuerySpecification(string name, bool isNotTracked = false) 
        : base(m => m.Name.Equals(name))
    {
        IsNotTracked = isNotTracked;
        AddInclude(m => m.VehicleBrand);
    }
}