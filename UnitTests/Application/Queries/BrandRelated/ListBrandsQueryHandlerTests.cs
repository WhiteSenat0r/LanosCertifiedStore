using Application.Dtos.BrandDtos;
using Application.Queries.Brands;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Moq;

namespace UnitTests.Application.Queries.BrandRelated;

public class ListBrandsQueryHandlerTests
{
    private readonly Mock<IRepository<VehicleBrand>> _repository = new();
    private readonly Mock<IMapper> _mapper = new();
    
    [Fact]
    public async void Handle_ReturnsHandledQueryResult()
    {
        // Arrange
        var brands = new List<VehicleBrand>
        {
            new("Brand1"), new("Brand2")
        };
        
        _repository.Setup(r =>
                r.GetAllEntitiesAsync(It.IsAny<BrandQuerySpecification>()))
            .ReturnsAsync(brands);
        
        _mapper.Setup(m => m.Map<IReadOnlyList<VehicleBrand>, IReadOnlyList<BrandDto>>(
                It.IsAny<IReadOnlyList<VehicleBrand>>()))
            .Returns((IReadOnlyList<VehicleBrand> source) =>
                source.Select(x => new BrandDto
                {
                    Name = x.Name
                }).ToList());
        
        var handler = new ListBrandsQueryHandler(_repository.Object, _mapper.Object);
        var query = new ListBrandsQuery();
        var result = await handler.Handle(query, default);
        
        // Assert
        Assert.NotNull(result);
    }
}