using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RepositoryRelated;

public interface IUserRepository
{
    Task CreateUserAsync(User user, string passwordHash);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
    void UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
    Task<bool> CheckPasswordAsync(string email, string passwordHash);
    Task<bool> AddUserToRole(Guid id, string role);
    Task<bool> RemoveUserFromRole(Guid id, string role);
}