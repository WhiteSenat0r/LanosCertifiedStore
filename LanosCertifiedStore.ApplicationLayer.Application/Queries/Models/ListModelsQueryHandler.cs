using Application.Core;
using Application.Dtos.ModelDtos;
using Application.QuerySpecifications.ModelRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Models;

internal sealed class ListModelsQueryHandler(IRepository<VehicleModel> modelRepository, IMapper mapper)
    : IRequestHandler<ListModelsQuery, Result<IReadOnlyList<ModelDto>>>
{
    public async Task<Result<IReadOnlyList<ModelDto>>> Handle(ListModelsQuery request,
        CancellationToken cancellationToken)
    {
        var models = await modelRepository.GetAllEntitiesAsync(new ModelQuerySpecification());

        var modelsToReturn = mapper.Map<IReadOnlyList<VehicleModel>, IReadOnlyList<ModelDto>>(models);

        return Result<IReadOnlyList<ModelDto>>.Success(modelsToReturn);
    }
}