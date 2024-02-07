using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ModelRelated;

public sealed class ModelByNameQuerySpecification(string name)
    : QuerySpecification<VehicleModel>(m => m.Name.Equals(name));