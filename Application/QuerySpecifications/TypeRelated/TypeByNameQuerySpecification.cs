using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.TypeRelated;

public class TypeByNameQuerySpecification(string name) 
    : QuerySpecification<VehicleType>(t => t.Name.Equals(name));