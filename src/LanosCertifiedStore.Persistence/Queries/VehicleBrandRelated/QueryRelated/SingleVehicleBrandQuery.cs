using AutoMapper;
using LanosCertifiedStore.Application.VehicleBrands.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class SingleVehicleBrandQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) :
    SingleQueryBase<VehicleBrand, SingleVehicleBrandDto>(
        context,
        mapper);