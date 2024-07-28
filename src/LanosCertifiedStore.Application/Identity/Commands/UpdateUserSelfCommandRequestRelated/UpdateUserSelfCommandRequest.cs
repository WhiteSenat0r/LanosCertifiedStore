using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;

public sealed record UpdateUserSelfCommandRequest(
    string FirstName,
    string LastName,
    string PhoneNumber) : ICommandRequest;