using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.VehicleDetails;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.VehicleRelated;

public class VehicleDetailsQueryHandlerTests
{
    private readonly Mock<IRepository<Vehicle>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var vehicles = GetVehicleList();
        
        _repository.Setup(r =>
                r.GetEntityByIdAsync(It.IsAny<VehicleByIdQuerySpecification>()))
            .ReturnsAsync(vehicles.First());
        
        _mapper.Setup(m => m.Map<Vehicle, VehicleDto>(It.IsAny<Vehicle>()))
            .Returns((Vehicle source) =>
                new VehicleDto
                {
                    Brand = source.Brand.Name,
                    Model = source.Model.Name,
                    Color = source.Color.Name,
                    Type = source.Type.Name,
                    Displacement = source.Displacement.Value
                });
        
        var handler = new VehicleDetailsQueryHandler(_repository.Object, _mapper.Object);
        var query = new VehicleDetailsQuery(Guid.Empty);
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }

    private List<Vehicle> GetVehicleList()
    {
        var brand = new VehicleBrand("BMW");
        var model = new VehicleModel(brand.Id, "M5");
        var displacement = new VehicleDisplacement(5d);
        var colors = new List<VehicleColor>
        {
            new("Red"), new("Black")
        };
        var type = new VehicleType("Sedan");

        return
        [
            new(brand.Id, model.Id, type.Id, colors[0].Id, displacement.Id, 125000m, "Test")
            {
                Brand = brand, Model = model, Color = colors[0], Type = type, Displacement = displacement
            },

            new(brand.Id, model.Id, type.Id, colors[1].Id, displacement.Id, 125500m, "Test")
            {
                Brand = brand, Model = model, Color = colors[1], Type = type, Displacement = displacement
            }
        ];
    }
}