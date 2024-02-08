using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.BrandRelated;

public sealed class BrandByNameQuerySpecification(string name)
    : QuerySpecification<VehicleBrand>(b => b.Name.Equals(name));