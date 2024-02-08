using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.DisplacementRelated;

public sealed class DisplacementByValueQuerySpecification(double value)
    : QuerySpecification<VehicleDisplacement>(m => m.Value.Equals(value));