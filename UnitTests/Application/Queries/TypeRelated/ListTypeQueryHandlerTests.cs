using Application.Dtos.TypeDtos;
using Application.Queries.Types;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.TypeRelated;

public class ListTypeQueryHandlerTests
{
    private readonly Mock<IRepository<VehicleType>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var types = new List<VehicleType>
        {
            new("Type1"), new("Type2")
        };
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<TypeQuerySpecification>()))
            .ReturnsAsync(types);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<VehicleType>, IReadOnlyList<TypeDto>>(
                    It.IsAny<IReadOnlyList<VehicleType>>()))
            .Returns((IReadOnlyList<VehicleType> source) =>
                source.Select(x => new TypeDto
                {
                    Name = x.Name
                }).ToList());
        
        var handler = new ListTypesQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListTypesQuery();
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }
}