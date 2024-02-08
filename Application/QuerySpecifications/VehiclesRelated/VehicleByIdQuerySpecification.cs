using Application.QuerySpecifications.Common.Classes;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.QuerySpecifications.VehiclesRelated;

public class VehicleByIdQuerySpecification(Guid id) : QuerySpecification<Vehicle>(x => x.Id == id);