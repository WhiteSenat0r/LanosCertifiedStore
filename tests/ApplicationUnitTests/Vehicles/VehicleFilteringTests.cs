using LanosCertifiedStore.Application.Vehicles;

namespace ApplicationUnitTests.Vehicles;

public sealed class VehicleFilteringTests
{
    [Theory]
    [InlineData("Brand", "Toyota")]
    [InlineData("Model", "Corolla")]
    [InlineData("Type", "Sedan")]
    [InlineData("Color", "Black")]
    public void VehicleFilteringRequestParameters_ShouldSetAndGet_StringProperties(string propertyName, string expectedValue)
    {
        // Arrange
        var parameters = new VehicleFilteringRequestParameters();

        // Act
        typeof(VehicleFilteringRequestParameters)
            .GetProperty(propertyName)!
            .SetValue(parameters, expectedValue);

        var actualValue = typeof(VehicleFilteringRequestParameters)
            .GetProperty(propertyName)!
            .GetValue(parameters);

        // Assert
        actualValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("LowerPriceLimit", 10000)]
    [InlineData("UpperPriceLimit", 50000)]
    public void VehicleFilteringRequestParameters_ShouldSetAndGet_DecimalProperties(string propertyName, decimal expectedValue)
    {
        // Arrange
        var parameters = new VehicleFilteringRequestParameters();

        // Act
        typeof(VehicleFilteringRequestParameters)
            .GetProperty(propertyName)!
            .SetValue(parameters, expectedValue);

        var actualValue = typeof(VehicleFilteringRequestParameters)
            .GetProperty(propertyName)!
            .GetValue(parameters);

        // Assert
        actualValue.Should().Be(expectedValue);
    }

    [Fact]
    public void VehicleFilteringRequestParameters_ShouldAllow_AllNullValues()
    {
        // Arrange & Act
        var parameters = new VehicleFilteringRequestParameters
        {
            Brand = null,
            Model = null,
            Type = null,
            Color = null,
            LowerPriceLimit = null,
            UpperPriceLimit = null
        };

        // Assert
        parameters.Brand.Should().BeNull();
        parameters.Model.Should().BeNull();
        parameters.Type.Should().BeNull();
        parameters.Color.Should().BeNull();
        parameters.LowerPriceLimit.Should().BeNull();
        parameters.UpperPriceLimit.Should().BeNull();
    }

    [Fact]
    public void VehicleFilteringRequestParameters_ShouldAllow_CombinedFilters()
    {
        // Arrange & Act
        var parameters = new VehicleFilteringRequestParameters
        {
            Brand = "Honda",
            Model = "Civic",
            Type = "Sedan",
            Color = "Red",
            LowerPriceLimit = 15000m,
            UpperPriceLimit = 25000m
        };

        // Assert
        parameters.Brand.Should().Be("Honda");
        parameters.Model.Should().Be("Civic");
        parameters.Type.Should().Be("Sedan");
        parameters.Color.Should().Be("Red");
        parameters.LowerPriceLimit.Should().Be(15000m);
        parameters.UpperPriceLimit.Should().Be(25000m);
    }
}
