using AutoMapper;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleModelRelated.QueryRelated;

public sealed class SingleVehicleModelQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) :
    SingleQueryBase<VehicleModel, SingleVehicleModelDto>(context, mapper);