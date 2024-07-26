using Application.Shared.RequestRelated;

namespace Application.Identity.Commands.RegisterUserCommandRequestRelated;

public sealed record AddUserFromProviderCommandRequest(Guid UserId) : ICommandRequest<Guid>;