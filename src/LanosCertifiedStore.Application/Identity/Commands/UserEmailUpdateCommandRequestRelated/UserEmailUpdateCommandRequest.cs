using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;

public sealed record UserEmailUpdateCommandRequest(string NewEmail) : ICommandRequest;