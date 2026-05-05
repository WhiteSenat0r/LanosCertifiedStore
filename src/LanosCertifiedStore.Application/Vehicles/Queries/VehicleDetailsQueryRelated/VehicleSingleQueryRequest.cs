using LanosCertifiedStore.Application.Shared.RequestParamsRelated.RequestBases;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehicleDetailsQueryRelated;

public sealed record VehicleSingleQueryRequest(Guid Id) : SingleQueryRequestBase<Vehicle, VehicleDto>(Id), IRequest<Result<VehicleDto>>;