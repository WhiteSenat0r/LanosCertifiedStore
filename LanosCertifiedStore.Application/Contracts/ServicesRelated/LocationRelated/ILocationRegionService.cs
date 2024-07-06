namespace Application.Contracts.ServicesRelated.LocationRelated;

public interface ILocationRegionService
{
    Task<bool> ExistsById(Guid regionId, CancellationToken cancellationToken);
}