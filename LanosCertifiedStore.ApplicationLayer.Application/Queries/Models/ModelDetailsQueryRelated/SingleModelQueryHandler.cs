using Application.Dtos.ModelDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Models.ModelDetailsQueryRelated;

internal sealed class SingleModelQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<SingleModelQuery, Result<ModelDto>>
{
    public async Task<Result<ModelDto>> Handle(SingleModelQuery request,
        CancellationToken cancellationToken)
    {
        var model = await unitOfWork.RetrieveRepository<VehicleModel>().GetEntityByIdAsync(request.Id);

        if (model is null) return null!;
        
        var modelToReturn = mapper.Map<VehicleModel, ModelDto>(model!);

        return Result<ModelDto>.Success(modelToReturn);
    }
}