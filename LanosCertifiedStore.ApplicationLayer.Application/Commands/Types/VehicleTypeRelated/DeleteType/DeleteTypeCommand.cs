﻿using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleTypeRelated.DeleteType;

public sealed record DeleteTypeCommand(Guid Id) : IRequest<Result<Unit>>;