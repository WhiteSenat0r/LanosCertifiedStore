﻿using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTypeRelated.CreateType;

public sealed record CreateTypeCommand(string Name) : IRequest<Result<Unit>>;