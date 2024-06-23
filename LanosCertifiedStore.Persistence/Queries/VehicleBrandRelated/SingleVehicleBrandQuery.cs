using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Models.VehicleRelated.Classes;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Entities.VehicleRelated;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated;

internal sealed class SingleVehicleBrandQuery(
    ApplicationDatabaseContext context,
    IQueryProjectionProfileSelector<VehicleBrand, VehicleBrandEntity> projectionProfileSelector,
    IMapper mapper) : SingleQueryBase<VehicleBrand, VehicleBrandEntity, VehicleBrandDto>(
    context,
    projectionProfileSelector,
    mapper);