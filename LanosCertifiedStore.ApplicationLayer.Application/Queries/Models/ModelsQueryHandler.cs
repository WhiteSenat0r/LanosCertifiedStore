using Application.Dtos.ModelDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models;

internal sealed class ModelsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ModelsQuery, Result<IReadOnlyList<ModelDto>>>
{
    public async Task<Result<IReadOnlyList<ModelDto>>> Handle(ModelsQuery request,
        CancellationToken cancellationToken)
    {
        var models = await unitOfWork.RetrieveRepository<VehicleModel>().GetAllEntitiesAsync(request.RequestParameters);

        var modelsToReturn = mapper.Map<IReadOnlyList<VehicleModel>, IReadOnlyList<ModelDto>>(models);

        return Result<IReadOnlyList<ModelDto>>.Success(modelsToReturn);
    }
}