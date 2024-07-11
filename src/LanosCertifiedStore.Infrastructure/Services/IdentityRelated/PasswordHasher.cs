using Application.Identity.ServicesContracts;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated;

internal sealed class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}