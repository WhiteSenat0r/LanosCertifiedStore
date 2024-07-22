using Application.Shared.RequestRelated;

namespace Application.Identity.Commands.RegisterUserCommandRequestRelated;

public sealed record RegisterUserCommandRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber) : ICommandRequest<Guid>;