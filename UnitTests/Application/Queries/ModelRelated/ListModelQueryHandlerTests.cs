using Application.Dtos.ModelDtos;
using Application.Queries.Models;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.ModelRelated;

public class ListModelQueryHandlerTests
{
    private readonly Mock<IRepository<VehicleModel>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var Models = new List<VehicleModel>
        {
            new(Guid.Empty, "Model1"), new(Guid.Empty, "Model2")
        };
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<ModelQuerySpecification>()))
            .ReturnsAsync(Models);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<VehicleModel>, IReadOnlyList<ModelDto>>(
                It.IsAny<IReadOnlyList<VehicleModel>>()))
            .Returns((IReadOnlyList<VehicleModel> source) =>
                source.Select(x => new ModelDto
                {
                    Name = x.Name
                }).ToList());
        
        var handler = new ListModelsQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListModelsQuery();
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }
}