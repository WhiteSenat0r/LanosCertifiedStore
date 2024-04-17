using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;

namespace Application.Commands.Models.UpdateModel.Common.Classes;

internal abstract class ModelUpdateMappings<TAspect>
    where TAspect : class
{
    public static readonly Dictionary<Type, Func<VehicleModel, TAspect>> SingleAspectMappings = new()
    {
        { typeof(VehicleBrand), model => (model.Brand as TAspect)! },
        { typeof(VehicleType), model => (model.VehicleType as TAspect)! },
        { typeof(VehicleBodyType), model => (model.AvailableBodyTypes as TAspect)! },
        { typeof(VehicleEngineType), model => (model.AvailableEngineTypes as TAspect)! },
        { typeof(VehicleTransmissionType), model => (model.AvailableTransmissionTypes as TAspect)! },
        { typeof(VehicleDrivetrainType), model => (model.AvailableDrivetrainTypes as TAspect)! },
    };
    
    public static readonly Dictionary<Type, Func<VehicleModel, ICollection<TAspect>>> MultipleAspectMappings = new()
    {
        { typeof(VehicleBodyType), model => (model.AvailableBodyTypes as ICollection<TAspect>)! },
        { typeof(VehicleEngineType), model => (model.AvailableEngineTypes as ICollection<TAspect>)! },
        { typeof(VehicleTransmissionType), model => (model.AvailableTransmissionTypes as ICollection<TAspect>)! },
        { typeof(VehicleDrivetrainType), model => (model.AvailableDrivetrainTypes as ICollection<TAspect>)! },
    };
    
    public static readonly Dictionary<Type, Action<VehicleModel, TAspect>> SingleAspectActionMappings = new()
    {
        { typeof(VehicleBrand), (model, aspect) => model.Brand = (aspect as VehicleBrand)! },
        { typeof(VehicleType), (model, aspect) => model.VehicleType = (aspect as VehicleType)! },
        {
            typeof(VehicleBodyType),
            (model, aspects) => model.AvailableBodyTypes = (aspects as ICollection<VehicleBodyType>)!
        },
        {
            typeof(VehicleEngineType),
            (model, aspects) => model.AvailableEngineTypes = (aspects as ICollection<VehicleEngineType>)!
        },
        {
            typeof(VehicleTransmissionType),
            (model, aspects) => model.AvailableTransmissionTypes = (aspects as ICollection<VehicleTransmissionType>)!
        },
        {
            typeof(VehicleDrivetrainType),
            (model, aspects) => model.AvailableDrivetrainTypes = (aspects as ICollection<VehicleDrivetrainType>)!
        },
    };
    
    public static readonly Dictionary<Type, Action<VehicleModel, ICollection<TAspect>>>
        MultipleAspectActionMappings = new()
    {
        {
            typeof(VehicleBodyType),
            (model, aspects) => model.AvailableBodyTypes = (aspects as ICollection<VehicleBodyType>)!
        },
        {
            typeof(VehicleEngineType),
            (model, aspects) => model.AvailableEngineTypes = (aspects as ICollection<VehicleEngineType>)!
        },
        {
            typeof(VehicleTransmissionType),
            (model, aspects) => model.AvailableTransmissionTypes = (aspects as ICollection<VehicleTransmissionType>)!
        },
        {
            typeof(VehicleDrivetrainType),
            (model, aspects) => model.AvailableDrivetrainTypes = (aspects as ICollection<VehicleDrivetrainType>)!
        },
    };
}