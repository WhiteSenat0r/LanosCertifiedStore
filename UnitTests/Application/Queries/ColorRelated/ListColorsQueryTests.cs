using Application.Queries.Colors;

namespace UnitTests.Application.Queries.ColorRelated;

public class ListColorsQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListColorsQuery();
        
        // Assert
        Assert.NotNull(result);
    }
}