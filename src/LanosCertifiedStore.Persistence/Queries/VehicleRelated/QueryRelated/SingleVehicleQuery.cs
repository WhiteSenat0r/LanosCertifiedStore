using AutoMapper;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class SingleVehicleQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) : SingleQueryBase<Vehicle, SingleVehicleDto>(context, mapper);