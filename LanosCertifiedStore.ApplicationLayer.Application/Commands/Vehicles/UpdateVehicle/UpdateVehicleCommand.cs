﻿using Application.Core;
using Application.Dtos.VehicleDtos;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

public record UpdateVehicleCommand(ActionVehicleDto ActionVehicleDto) : IRequest<Result<Unit>>;