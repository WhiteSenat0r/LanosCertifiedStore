using Application.Queries.Brands;

namespace UnitTests.Application.Queries.BrandRelated;

public class ListBrandsQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListBrandsQuery();
        
        // Assert
        Assert.NotNull(result);
    }
}