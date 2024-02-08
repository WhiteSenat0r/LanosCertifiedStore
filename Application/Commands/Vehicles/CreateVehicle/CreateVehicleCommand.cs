using Application.Core;
using Application.Dtos.VehicleDtos;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

public record CreateVehicleCommand(CreateVehicleDto Vehicle) : IRequest<Result<Unit>>;