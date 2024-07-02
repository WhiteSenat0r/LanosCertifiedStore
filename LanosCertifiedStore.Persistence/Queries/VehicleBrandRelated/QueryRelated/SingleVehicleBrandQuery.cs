using Application.Dtos.BrandDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class SingleVehicleBrandQuery(
    ApplicationDatabaseContext context, 
    IQueryProjectionProfileSelector<VehicleBrand> projectionProfileSelector,
    IMapper mapper) : 
    SingleQueryBase<VehicleBrand, VehicleBrandDto>(context, projectionProfileSelector, mapper);