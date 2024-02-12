using Application.Queries.Types;

namespace UnitTests.Application.Queries.TypeRelated;

public class ListTypeQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListTypesQuery();
        
        // Assert
        Assert.NotNull(result);
    }
}