using Application.VehicleModels.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.VehicleModelRelated.QueryRelated;

public sealed class SingleVehicleModelQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) :
    SingleQueryBase<VehicleModel, SingleVehicleModelDto>(context, mapper);