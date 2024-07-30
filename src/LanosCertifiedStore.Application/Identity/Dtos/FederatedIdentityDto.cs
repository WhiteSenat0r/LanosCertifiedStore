namespace LanosCertifiedStore.Application.Identity;

public sealed record FederatedIdentityDto(string IdentityProvider, string UserId, string UserName);