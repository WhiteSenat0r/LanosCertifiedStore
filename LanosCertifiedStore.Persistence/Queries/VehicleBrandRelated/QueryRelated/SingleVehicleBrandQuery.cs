using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class SingleVehicleBrandQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) :
    SingleQueryBase<VehicleBrand, VehicleBrandWithRelatedModelsDto>(
        context,
        mapper);