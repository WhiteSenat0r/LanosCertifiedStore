using Domain.Contracts.RepositoryRelated;
using Domain.Entities.UserRelated;
using Domain.Entities.VehicleRelated.Classes;
using Persistence.Repositories.IdentityRelated;
using Persistence.Repositories.VehicleBrandRelated;
using Persistence.Repositories.VehicleColorRelated;
using Persistence.Repositories.VehicleImageRelated;
using Persistence.Repositories.VehicleModelRelated;
using Persistence.Repositories.VehiclePriceRelated;
using Persistence.Repositories.VehicleRelated;
using Persistence.Repositories.VehicleTypeRelated;

namespace Persistence.UnitOfWorkRelated.Common.Classes;

internal abstract class RepositoryMappings
{
    public static readonly Dictionary<Type, Type> VehicleRelatedRepositoryMappings = new()
    {
        { typeof(IRepository<Vehicle>), typeof(VehicleRepository) },
        { typeof(IRepository<VehicleBrand>), typeof(VehicleBrandRepository) },
        { typeof(IRepository<VehicleModel>), typeof(VehicleModelRepository) },
        { typeof(IRepository<VehicleType>), typeof(VehicleTypeRepository) },
        { typeof(IRepository<VehicleColor>), typeof(VehicleColorRepository) },
        { typeof(IRepository<VehiclePrice>), typeof(VehiclePriceRepository) },
        { typeof(IRepository<VehicleImage>), typeof(VehicleImageRepository) },
        { typeof(IRepository<User>), typeof(UserRepository) }
    };
}