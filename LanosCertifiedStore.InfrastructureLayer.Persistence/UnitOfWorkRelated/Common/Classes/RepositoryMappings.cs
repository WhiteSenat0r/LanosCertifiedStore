using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Persistence.Repositories.TypeRelated.VehicleBodyTypeRelated;
using Persistence.Repositories.TypeRelated.VehicleDrivetrainTypeRelated;
using Persistence.Repositories.TypeRelated.VehicleEngineTypeRelated;
using Persistence.Repositories.TypeRelated.VehicleTransmissionTypeRelated;
using Persistence.Repositories.TypeRelated.VehicleTypeRelated;
using Persistence.Repositories.VehicleBrandRelated;
using Persistence.Repositories.VehicleColorRelated;
using Persistence.Repositories.VehicleImageRelated;
using Persistence.Repositories.VehicleModelRelated;
using Persistence.Repositories.VehiclePriceRelated;
using Persistence.Repositories.VehicleRelated;

namespace Persistence.UnitOfWorkRelated.Common.Classes;

internal abstract class RepositoryMappings
{
    public static readonly Dictionary<Type, Type> VehicleRelatedRepositoryMappings = new()
    {
        { typeof(IRepository<Vehicle>), typeof(VehicleRepository) },
        { typeof(IRepository<VehicleBrand>), typeof(VehicleBrandRepository) },
        { typeof(IRepository<VehicleModel>), typeof(VehicleModelRepository) },
        { typeof(IRepository<VehicleType>), typeof(VehicleTypeRepository) },
        { typeof(IRepository<VehicleEngineType>), typeof(VehicleEngineTypeRepository) },
        { typeof(IRepository<VehicleTransmissionType>), typeof(VehicleTransmissionTypeRepository) },
        { typeof(IRepository<VehicleDrivetrainType>), typeof(VehicleDrivetrainTypeRepository) },
        { typeof(IRepository<VehicleBodyType>), typeof(VehicleBodyTypeRepository) },
        { typeof(IRepository<VehicleColor>), typeof(VehicleColorRepository) },
        { typeof(IRepository<VehiclePrice>), typeof(VehiclePriceRepository) },
        { typeof(IRepository<VehicleImage>), typeof(VehicleImageRepository) },
        // { typeof(IRepository<User>), typeof(UserRepository) }
    };
}