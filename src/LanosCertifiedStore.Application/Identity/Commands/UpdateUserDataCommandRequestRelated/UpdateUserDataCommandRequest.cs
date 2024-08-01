using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;

public sealed record UpdateUserDataCommandRequest(
    Guid Id,
    string PhoneNumber,
    string Email,
    bool EmailVerified,
    string FirstName,
    string LastName) : ICommandRequest;