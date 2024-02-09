using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ModelRelated;

public sealed class ModelQuerySpecification : QuerySpecification<VehicleModel>
{
    public ModelQuerySpecification(bool isNotTracked = false)
    {
        IsNotTracked = isNotTracked;
        AddInclude(m => m.VehicleBrand);
    }
}