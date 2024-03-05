using Application.Dtos.VehicleDtos;
using Application.Queries.Common.DetailsQueryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehicleDetailsQueryRelated;

public sealed record VehicleDetailsQuery(Guid Id) : DetailsQueryBase<Vehicle>(Id), IRequest<Result<SingleVehicleDto>>;