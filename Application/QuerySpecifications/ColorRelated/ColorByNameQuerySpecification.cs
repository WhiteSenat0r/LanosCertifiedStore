using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.ColorRelated;

public sealed class ColorByNameQuerySpecification(string name)
    : QuerySpecification<VehicleColor>(c => c.Name.Equals(name));