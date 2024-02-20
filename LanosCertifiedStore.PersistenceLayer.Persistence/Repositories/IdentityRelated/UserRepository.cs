using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.DataModels;

namespace Persistence.Repositories.IdentityRelated;

internal sealed class UserRepository(
    ApplicationDatabaseContext dbContext,
    IMapper mapper) : IUserRepository
{
    public async Task CreateUserAsync(User user, string passwordHash)
    {
        var userDataModel = mapper.Map<User, UserDataModel>(user);

        userDataModel.PasswordHash = passwordHash;

        var defaultUserRole = await dbContext.Set<UserRoleDataModel>().FirstOrDefaultAsync(x => x.Name == "User");

        userDataModel.Roles.Add(defaultUserRole!);

        await dbContext.Set<UserDataModel>().AddAsync(userDataModel);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var userModel = await dbContext.Set<UserDataModel>().FindAsync(id);

        return userModel is null ? null : mapper.Map<UserDataModel, User>(userModel);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var userModel = await dbContext.Set<UserDataModel>().FirstOrDefaultAsync(x => x.Email.Equals(email));

        return userModel is null ? null : mapper.Map<UserDataModel, User>(userModel);
    }

    public void UpdateUserAsync(User user)
    {
        var userModel = mapper.Map<User, UserDataModel>(user);

        dbContext.Set<UserDataModel>().Update(userModel);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var userToDelete = await dbContext.Set<UserDataModel>().FindAsync(id);

        if (userToDelete is not null)
            dbContext.Set<UserDataModel>().Remove(userToDelete);
    }

    public async Task<bool> CheckPasswordAsync(string email, string passwordHash)
    {
        var user = await dbContext.Set<UserDataModel>().FirstOrDefaultAsync(x => x.Email == email);

        if (user is null) return false;

        return user.PasswordHash == passwordHash;
    }

    public async Task<bool> AddUserToRole(Guid id, string role)
    {
        var user = await dbContext.Set<UserDataModel>()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (user is null)
            return false;

        var existingRole = await dbContext.Set<UserRoleDataModel>().SingleOrDefaultAsync(r => r.Name == role);

        if (existingRole is null)
            return false;

        if (user.Roles.Any(x => x.Equals(existingRole)))
            return false;

        user.Roles.Add(existingRole);

        return true;
    }

    public async Task<bool> RemoveUserFromRole(Guid id, string role)
    {
        var user = await dbContext.Set<UserDataModel>()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (user is null)
            return false;

        var existingRole = await dbContext.Set<UserRoleDataModel>().SingleOrDefaultAsync(r => r.Name == role);

        if (existingRole is null)
            return false;

        if (!user.Roles.Any(x => x.Equals(existingRole)))
            return false;

        user.Roles.Remove(existingRole);

        return true;
    }
}