using Application.Dtos.VehicleDtos;
using Application.Queries.Vehicles.ListVehicles;
using Application.QuerySpecifications.VehiclesRelated;
using Application.RequestParams;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.VehicleRelated;

public class ListVehicleQueryHandlerTests
{
    private readonly Mock<IRepository<Vehicle>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var vehicles = GetVehicleList();
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<VehicleQuerySpecification>()))
            .ReturnsAsync(vehicles);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleDto>>(
                    It.IsAny<IReadOnlyList<Vehicle>>()))
            .Returns((IReadOnlyList<Vehicle> source) =>
                source.Select(v => new VehicleDto
                {
                    Brand = v.Brand.Name,
                    Model = v.Model.Name,
                    Color = v.Color.Name,
                    Type = v.Type.Name,
                    Displacement = v.Displacement.Value
                }).ToList());
        
        var handler = new ListVehiclesQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListVehiclesQuery(new VehicleRequestParameters());
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