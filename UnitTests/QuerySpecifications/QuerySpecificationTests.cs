namespace UnitTests.QuerySpecifications;

public class QuerySpecificationTests
{
    [Theory]
    [InlineData(typeof(BrandQuerySpecification))]
    [InlineData(typeof(TypeQuerySpecification))]
    [InlineData(typeof(ModelQuerySpecification))]
    [InlineData(typeof(DisplacementQuerySpecification))]
    [InlineData(typeof(ColorQuerySpecification))]
    [InlineData(typeof(VehicleQuerySpecification))]
    public void Query_Should_NotBeNull(Type querySpecificationType)
    {
        // Find the constructor with parameters and invoke it with 'false'
        var constructorInfo = querySpecificationType.GetConstructor([typeof(bool)]);

        if (constructorInfo != null)
        {
            var specification = constructorInfo.Invoke([false]);
            Assert.NotNull(specification);
        }

        if (querySpecificationType != typeof(VehicleQuerySpecification)) return;
        
        var ctorInfo = querySpecificationType.GetConstructor([typeof(VehicleRequestParameters)]);
        var vehicleSpecification = ctorInfo!.Invoke([new VehicleRequestParameters()]);
        Assert.NotNull(vehicleSpecification);
    }
}