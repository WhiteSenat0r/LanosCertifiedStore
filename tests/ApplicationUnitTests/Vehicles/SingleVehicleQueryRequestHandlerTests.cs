using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;

namespace ApplicationUnitTests.Vehicles;

public sealed class SingleVehicleQueryRequestHandlerTests
{
    private readonly IVehicleService _vehicleService = Substitute.For<IVehicleService>();
    private readonly IUserContext _userContext = Substitute.For<IUserContext>();
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();
    private readonly SingleVehicleQueryRequestHandler _handler;
    private readonly SingleVehicleQueryRequest _request;
    private readonly Guid _vehicleId = Guid.NewGuid();
    private readonly Guid _ownerId = Guid.NewGuid();

    public SingleVehicleQueryRequestHandlerTests()
    {
        _request = new SingleVehicleQueryRequest(_vehicleId);
        _handler = new SingleVehicleQueryRequestHandler(_vehicleService, _identityProviderService, _userContext);
    }

    [Fact]
    public async Task Handle_WhenVehicleNotFound_ShouldReturnNotFoundError()
    {
        // Arrange
        _vehicleService
            .GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns((SingleVehicleDto?)null);

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(Error.NotFound(_vehicleId));
        await _identityProviderService
            .DidNotReceive()
            .GetUserDataAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_WhenVehicleFound_ShouldReturnVehicleWithOwnerData()
    {
        // Arrange
        var vehicleDto = CreateSampleVehicleDto();
        var ownerData = CreateSampleOwnerData();

        _vehicleService
            .GetVehicle(Arg.Is<SingleVehicleQueryRequest>(r => r.ItemId == _vehicleId), Arg.Any<CancellationToken>())
            .Returns(vehicleDto);

        _identityProviderService
            .GetUserDataAsync(_ownerId, Arg.Any<CancellationToken>())
            .Returns(Result<UserDataDto>.Success(ownerData));

        // Act
        var result = await _handler.Handle(_request, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Id.Should().Be(_vehicleId);
        result.Value.OwnerId.Should().Be(_ownerId);
        
        // Verify owner data is correctly mapped
        result.Value.OwnerData.Should().NotBeNull();
        result.Value.OwnerData.FirstName.Should().Be(ownerData.FirstName);
        result.Value.OwnerData.LastName.Should().Be(ownerData.LastName);
        result.Value.OwnerData.Email.Should().Be(ownerData.Email);
        result.Value.OwnerData.PhoneNumber.Should().Be(ownerData.PhoneNumber);
    }

    [Fact]
    public async Task Handle_ShouldCallVehicleServiceWithCorrectRequest()
    {
        // Arrange
        var vehicleDto = CreateSampleVehicleDto();
        var ownerData = CreateSampleOwnerData();

        _vehicleService
            .GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicleDto);

        _identityProviderService
            .GetUserDataAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Result<UserDataDto>.Success(ownerData));

        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _vehicleService
            .Received(1)
            .GetVehicle(Arg.Is<SingleVehicleQueryRequest>(r => 
                    r.ItemId == _vehicleId), 
                Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldCallIdentityProviderWithCorrectOwnerId()
    {
        // Arrange
        var vehicleDto = CreateSampleVehicleDto();
        var ownerData = CreateSampleOwnerData();

        _vehicleService
            .GetVehicle(Arg.Any<SingleVehicleQueryRequest>(), Arg.Any<CancellationToken>())
            .Returns(vehicleDto);

        _identityProviderService
            .GetUserDataAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Result<UserDataDto>.Success(ownerData));

        // Act
        await _handler.Handle(_request, default);

        // Assert
        await _identityProviderService
            .Received(1)
            .GetUserDataAsync(_ownerId, Arg.Any<CancellationToken>());
    }

    private SingleVehicleDto CreateSampleVehicleDto()
    {
        return new SingleVehicleDto
        {
            Id = _vehicleId,
            OwnerId = _ownerId,
            Brand = "Test Brand",
            Model = "Test Model",
            ProductionYear = 2020,
            Mileage = 50000,
            Vincode = "TEST123456789",
            CreatedAt = DateTime.UtcNow
        };
    }

    private UserDataDto CreateSampleOwnerData()
    {
        return new UserDataDto(
            _ownerId.ToString(),
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            false,
            [],
            default);
    }
}