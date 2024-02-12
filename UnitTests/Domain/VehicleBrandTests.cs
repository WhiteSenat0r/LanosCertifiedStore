using Domain.Entities.VehicleRelated.Classes;

namespace UnitTests.Domain;


public class VehicleBrandTests
{
    [Fact]
    public void ConstructorWithName_SetsName()
    {
        // Arrange
        var brandName = "Toyota";

        // Act
        var brand = new VehicleBrand(brandName);

        // Assert
        Assert.Equal(brandName, brand.Name);
    }

    [Fact]
    public void ConstructorWithName_SetsModelsCollection()
    {
        // Arrange
        var brandName = "Toyota";

        // Act
        var brand = new VehicleBrand(brandName);

        // Assert
        Assert.NotNull(brand.Models);
        Assert.Empty(brand.Models);
    }

    [Fact]
    public void DefaultConstructor_SetsEmptyName()
    {
        // Arrange & Act
        var brand = new VehicleBrand();

        // Assert
        Assert.Null(brand.Name);
    }
    
    [Fact]
    public void Id_ValueHasToBeAbleToSetNewData()
    {
        // Arrange & Act
        var brand = new VehicleBrand
        {
            Id = Guid.Empty
        };

        // Assert
        Assert.Equal(Guid.Empty, brand.Id);
    }

    [Fact]
    public void AddModel_AddsModelToModelsCollection()
    {
        // Arrange
        var brand = new VehicleBrand("Toyota");
        var model = new VehicleModel(brand.Id, "Camry");

        // Act
        brand.Models.Add(model);

        // Assert
        Assert.Contains(model, brand.Models);
    }

    [Fact]
    public void RemoveModel_RemovesModelFromModelsCollection()
    {
        // Arrange
        var brand = new VehicleBrand("Toyota");
        var model = new VehicleModel(brand.Id, "Camry");
        brand.Models.Add(model);

        // Act
        brand.Models.Remove(model);

        // Assert
        Assert.DoesNotContain(model, brand.Models);
    }
    
    [Fact]
    public void ModelCollection_CanBeAssignedWithTheExistingCollection()
    {
        // Arrange
        var brand = new VehicleBrand("Toyota");
        var collection = new List<VehicleModel>
        {
            new(brand.Id, "Camry"),
            new(brand.Id, "Supra")
        };

        // Act
        brand.Models = collection;

        // Assert
        Assert.Equal(collection, brand.Models);
    }
}