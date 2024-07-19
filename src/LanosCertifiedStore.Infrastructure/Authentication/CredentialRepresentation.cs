namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication;

internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);
