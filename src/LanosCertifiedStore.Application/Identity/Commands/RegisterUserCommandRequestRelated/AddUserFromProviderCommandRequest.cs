using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.RegisterUserCommandRequestRelated;

public sealed record AddUserFromProviderCommandRequest(Guid UserId) : ICommandRequest<Guid>;