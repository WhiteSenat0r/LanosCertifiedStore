using Domain.Entities.VehicleRelated.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Repositories;

namespace UnitTests.Persistence;

public class GenericRepositoryRelatedTests
{
    private ApplicationDatabaseContext _context = null!;

    [Theory]
    [InlineData(typeof(VehicleRepository))]
    [InlineData(typeof(VehicleBrandRepository))]
    [InlineData(typeof(VehicleModelRepository))]
    [InlineData(typeof(VehicleTypeRepository))]
    [InlineData(typeof(VehiclePriceRepository))]
    [InlineData(typeof(VehicleColorRepository))]
    [InlineData(typeof(VehicleDisplacementRepository))]
    public async void Constructor_InstantiatesNewRepositoryObject(Type repositoryType)
    {
        // Arrange
        _context = await InstantiateDbContext();
        
        // Act
        var repository = Activator.CreateInstance(repositoryType, _context);
        
        // Assert
        Assert.NotNull(repository);
    }
    
    [Fact]
    public async void GetAllEntitiesAsync_ReturnsAllObjectsFromCurrentRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        
        // Act
        var result = await new VehicleBrandRepository(_context).GetAllEntitiesAsync(
            new BrandQuerySpecification(true));
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
    }
    
    [Fact]
    public async void GetSingleEntityBySpecificationAsync_ReturnsSingleObjectFromCurrentRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        
        // Act
        var result = await new VehicleBrandRepository(_context).GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification("Brand1"));
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Brand1", result.Name);
    }
    
    [Fact]
    public async void AddNewEntityAsync_AddsNewEntityToRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var addedEntity = new VehicleBrand("BrandAdded1");
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var resultBeforeAdding = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification("BrandAdded1"));
        
        // Assert
        Assert.Null(resultBeforeAdding);
        
        // Act
        await repository.AddNewEntityAsync(addedEntity);

        await unitOfWork.SaveChangesAsync();
        
        var resultAfterAdding = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification("BrandAdded1"));
        
        // Assert
        Assert.NotNull(resultAfterAdding);
    }
    
    [Fact]
    public async void AddRangeOfNewEntitiesAsync_AddsNewRangeOfEntitiesToRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var addedEntities = new List<VehicleBrand>
        {
            new("BrandAdded1"), new("BrandAdded1"),
        };
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var resultBeforeAdding = await repository.GetAllEntitiesAsync(new BrandQuerySpecification());
        
        // Assert
        Assert.Equal(3, resultBeforeAdding.Count);
        
        // Act
        await repository.AddNewRangeOfEntitiesAsync(addedEntities);

        await unitOfWork.SaveChangesAsync();
        
        var resultAfterAdding = await repository.GetAllEntitiesAsync(new BrandQuerySpecification());
        
        // Assert
        Assert.Equal(5, resultAfterAdding.Count);
    }
    
    [Fact]
    public async void UpdateExistingEntity_UpdatesExistingEntityInRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var updatedEntityName = "Brand1";
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var editedEntity = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification(updatedEntityName));

        editedEntity.Name = "UpdatedBrand1";

        repository.UpdateExistingEntity(editedEntity);
        
        await unitOfWork.SaveChangesAsync();
        
        var updatedEntity = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification("UpdatedBrand1"));
        
        // Assert
        Assert.NotNull(updatedEntity);
        Assert.Equal("UpdatedBrand1", updatedEntity.Name);
    }
    
    [Fact]
    public async void UpdateRangeOfExistingEntities_UpdatesRangeOfExistingEntitiesInRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var updatedEntityNames = new [] { "Brand1", "Brand2" };
        var editedEntityNames = new [] { "UpdatedBrand1", "UpdatedBrand2" };
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var objects = new List<VehicleBrand>();

        foreach (var name in updatedEntityNames)
        {
            var editedEntity = await repository.GetSingleEntityBySpecificationAsync(
                new BrandByNameQuerySpecification(name));
            
            objects.Add(editedEntity);
        }

        for (var i = 0; i < objects.Count; i++)
            objects[i].Name = editedEntityNames[i];
        
        repository.UpdateRangeOfExistingEntities(objects);
        
        await unitOfWork.SaveChangesAsync();
        
        var result = (await repository.GetAllEntitiesAsync(
            new BrandQuerySpecification())).Where(b => 
            b.Name.Equals(editedEntityNames[0]) || b.Name.Equals(editedEntityNames[1]));
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
    
    [Fact]
    public async void RemoveExistingEntity_RemovesExistingEntityFromRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var removedEntityNames = new [] { "Brand1", "Brand2" };
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var removedEntities = (await repository.GetAllEntitiesAsync(
            new BrandQuerySpecification())).Where(b => removedEntityNames.Contains(b.Name));

        repository.RemoveRangeOfExistingEntities(removedEntities);
        
        await unitOfWork.SaveChangesAsync();
        
        var result = await repository.GetAllEntitiesAsync(new BrandQuerySpecification());
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Count);
    }
    
    [Fact]
    public async void RemoveRangeOfExistingEntities_RemovesRangeOfExistingEntitiesFromRepository()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var removedEntityName = "Brand1";
        var repository = new VehicleBrandRepository(_context);
        var unitOfWork = new UnitOfWork(_context);
        
        // Act
        var removedEntity = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification(removedEntityName));

        repository.RemoveExistingEntity(removedEntity);
        
        await unitOfWork.SaveChangesAsync();
        
        var result = await repository.GetSingleEntityBySpecificationAsync(
            new BrandByNameQuerySpecification(removedEntityName));
        
        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public async void CountAsync_ReturnsCountOfItemsInQuery()
    {
        // Arrange
        _context = await InstantiateDbContext();
        var repository = new VehicleBrandRepository(_context);
        
        // Act
        var result = await repository.CountAsync(new BrandByNameQuerySpecification("Brand1"));
        
        // Assert
        Assert.Equal(1, result);
    }
    
    private async Task<ApplicationDatabaseContext> InstantiateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "dbTest")
            .Options;

        var context = new ApplicationDatabaseContext(options);

        if (context.VehiclesBrands.IsNullOrEmpty())
            context.VehiclesBrands.AddRange(new List<VehicleBrand>
            {
                new("Brand1"), new("Brand2"), new("Brand3")
            });
        else
        {
            context.VehiclesBrands.RemoveRange(context.VehiclesBrands);
            context.VehiclesBrands.AddRange(new List<VehicleBrand>
            {
                new("Brand1"), new("Brand2"), new("Brand3")
            });
        }

        await context.SaveChangesAsync();

        return context;
    }
}