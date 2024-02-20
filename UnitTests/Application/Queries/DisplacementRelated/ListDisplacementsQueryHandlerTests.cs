using Application.Dtos.DisplacementDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Moq;

namespace UnitTests.Application.Queries.DisplacementRelated;

public class ListDisplacementsQueryHandlerTests
{
    private readonly Mock<IRepository<VehicleDisplacement>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var displacements = new List<VehicleDisplacement>
        {
            new(1d), new(2d)
        };
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<DisplacementQuerySpecification>()))
            .ReturnsAsync(displacements);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<VehicleDisplacement>, IReadOnlyList<DisplacementDto>>(
                It.IsAny<IReadOnlyList<VehicleDisplacement>>()))
            .Returns((IReadOnlyList<VehicleDisplacement> source) =>
                source.Select(x => new DisplacementDto
                {
                    Value = x.Value
                }).ToList());
        
        var handler = new ListDisplacementsQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListDisplacementsQuery();
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }
}