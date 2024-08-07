﻿using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;

public sealed record AddUserFromProviderCommandRequest(Guid UserId) : ICommandRequest<Guid>;