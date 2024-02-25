namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}