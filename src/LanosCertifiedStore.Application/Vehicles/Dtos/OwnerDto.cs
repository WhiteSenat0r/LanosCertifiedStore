namespace LanosCertifiedStore.Application.Vehicles.Dtos;

public sealed record OwnerDto(
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber);