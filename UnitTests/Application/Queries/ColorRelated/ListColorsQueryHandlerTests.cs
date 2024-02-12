using Application.Dtos.ColorDtos;
using Application.Queries.Colors;
using Application.QuerySpecifications.ColorRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.ColorRelated;

public class ListColorsQueryHandlerTests
{
    private readonly Mock<IRepository<VehicleColor>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var colors = new List<VehicleColor>
        {
            new("Color1"), new("Color2")
        };
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<ColorQuerySpecification>()))
            .ReturnsAsync(colors);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<VehicleColor>, IReadOnlyList<ColorDto>>(
                It.IsAny<IReadOnlyList<VehicleColor>>()))
            .Returns((IReadOnlyList<VehicleColor> source) =>
                source.Select(x => new ColorDto
                {
                    Name = x.Name
                }).ToList());
        
        var handler = new ListColorsQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListColorsQuery();
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }
}