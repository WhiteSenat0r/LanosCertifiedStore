using Application.Dtos.VehicleDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetailsQueryRelated;

public sealed record VehicleDetailsQuery(Guid Id) : DetailsQueryBase<Vehicle>(Id), IRequest<Result<VehicleDto>>;