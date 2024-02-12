using Application.Queries.Models;

namespace UnitTests.Application.Queries.ModelRelated;

public class ListModelQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListModelsQuery();
        
        // Assert
        Assert.NotNull(result);
    }
}