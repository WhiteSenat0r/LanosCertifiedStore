namespace UnitTests.Application.Queries.DisplacementRelated;

public class ListDisplacementsQueryTests
{
    [Fact]
    public void Constructor_InstantiatesNewQuery()
    {
        // Arrange & Act
        var result = new ListDisplacementsQuery();
        
        // Assert
        Assert.NotNull(result);
    }
}