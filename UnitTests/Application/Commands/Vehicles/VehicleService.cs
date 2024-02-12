using Application.Dtos.VehicleDtos;
using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Application.Commands.Vehicles;

internal sealed class VehicleService
{
    public static ActionVehicleDto GetActionVehicleDto()
    {
        var brand = new VehicleBrand("test brand");
        var color = new VehicleColor("test color");
        var displacement = new VehicleDisplacement(2.0);
        var type = new VehicleType("test type");
        var model = new VehicleModel(brand.Id, "test model");

        return new ActionVehicleDto
        {
            Id = Guid.NewGuid(),
            Description = "some test description",
            BrandId = brand.Id,
            ColorId = color.Id,
            DisplacementId = displacement.Id,
            TypeId = type.Id,
            ModelId = model.Id,
            Price = 35000
        };
    }
    
    public static Vehicle GetVehicle(ActionVehicleDto actionVehicleDto)
    {
        return new Vehicle(
            brandId: actionVehicleDto.BrandId,
            modelId: actionVehicleDto.ModelId,
            typeId: actionVehicleDto.TypeId,
            colorId: actionVehicleDto.ColorId,
            displacementId: actionVehicleDto.DisplacementId,
            price: actionVehicleDto.Price,
            description: actionVehicleDto.Description);
    }
}