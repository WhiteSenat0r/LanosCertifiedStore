﻿using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypesRelated.UpdateBodyType;

public sealed record UpdateBodyTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;