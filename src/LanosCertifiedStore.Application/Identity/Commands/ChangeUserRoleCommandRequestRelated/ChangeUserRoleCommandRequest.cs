using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.Identity.Commands.ChangeUserRoleCommandRequestRelated;

public sealed record ChangeUserRoleCommandRequest(Guid UserId, string RoleCode) : ICommandRequest;