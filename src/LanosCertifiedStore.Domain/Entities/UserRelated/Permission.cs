// ReSharper disable InconsistentNaming

namespace Domain.Entities.UserRelated;

public sealed class Permission
{
    // Users
    public static readonly Permission GetUser = new("users:read");
    public static readonly Permission ListUsers = new("users:list");
    public static readonly Permission CreateUser = new("users:create");
    public static readonly Permission UpdateUser = new("users:update");
    public static readonly Permission ChangeUserRole = new("users:change-role");

    // Vehicles
    public static readonly Permission CreateVehicles = new("vehicles:create");
    public static readonly Permission UpdateVehicles = new("vehicles:update");
    public static readonly Permission DeleteVehicles = new("vehicles:delete");
    
    // Brands
    public static readonly Permission CreateBrands = new("brands:create");
    public static readonly Permission UpdateBrands = new("brands:update");

    // Models
    public static readonly Permission CreateModel = new("models:create");
    public static readonly Permission UpdateModel = new("models:update");

    public Permission()
    {
    }

    public Permission(string code)
    {
        Code = code;
    }

    public string Code { get; }
}