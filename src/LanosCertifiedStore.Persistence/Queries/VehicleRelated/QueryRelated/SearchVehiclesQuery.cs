using System.Text.RegularExpressions;
using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class SearchVehiclesQuery(
    ApplicationDatabaseContext context,
    IMapper mapper,
    IQueryPaginator queryPaginator) : CollectionQueryBase<Vehicle, SearchVehicleDto>
{
    public override async Task<IReadOnlyCollection<SearchVehicleDto>> Execute<TRequestResult>(
        IQueryRequest<Vehicle, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);
        var searchTerm = (queryRequest.FilteringParameters as ISearchVehicleFilteringRequestParameters)!.SearchTerm;

        var rankedVehicles = SearchRelevantVehicles(queryable, searchTerm);
        var paginatedVehicles = GetPaginatedQueryable(queryRequest, rankedVehicles, queryPaginator);

        var vehicles = await GetQueryResult(paginatedVehicles, mapper, cancellationToken);

        return vehicles;
    }

    private IQueryable<Vehicle> SearchRelevantVehicles(IQueryable<Vehicle> queryable, string searchTerm)
    {
        var tokens = Regex.Split(searchTerm.ToLower(), @"[\s,.;:\-\|]+")
            .Where(token => !string.IsNullOrEmpty(token))
            .ToList();

        var predicate = PredicateBuilder.New<Vehicle>();

        predicate = tokens.Select(token => $"%{token}%").Aggregate(predicate,
            (current, tokenPattern) => current.Or(vehicle =>
                EF.Functions.ILike(vehicle.Brand.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.Model.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.Color.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.BodyType.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.TransmissionType.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.EngineType.Name, tokenPattern) ||
                EF.Functions.ILike(vehicle.ProductionYear.ToString(), tokenPattern)));

        return queryable
            .Where(predicate)
            .OrderByDescending(v =>
                (tokens.Any(t => v.Brand.Name.ToLower() == t) ? 100 : 0) +
                (tokens.Any(t => v.Model.Name.ToLower() == t) ? 100 : 0) +
                tokens.Count(t => v.Brand.Name.ToLower().Contains(t)) * 20 +
                tokens.Count(t => v.Model.Name.ToLower().Contains(t)) * 20 +
                tokens.Count(t => v.Color.Name.ToLower().Contains(t)) * 10 +
                tokens.Count(t => v.BodyType.Name.ToLower().Contains(t)) * 10 +
                (tokens.Any(t => v.ProductionYear.ToString().Contains(t)) ? 15 : 0)
            );
    }
}