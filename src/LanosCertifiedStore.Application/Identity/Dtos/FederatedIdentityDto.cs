namespace LanosCertifiedStore.Application.Identity.Dtos;

public sealed record FederatedIdentityDto(string IdentityProvider, string UserId, string UserName);