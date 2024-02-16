using Application.Dtos.DisplacementDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Displacements;

internal sealed class ListDisplacementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListDisplacementsQuery, Result<IReadOnlyList<DisplacementDto>>>
{
    public async Task<Result<IReadOnlyList<DisplacementDto>>> Handle(ListDisplacementsQuery request,
        CancellationToken cancellationToken)
    {
        var displacements = await unitOfWork.RetrieveRepository<VehicleDisplacement>().GetAllEntitiesAsync();

        var displacementsToReturn = mapper.Map
            <IReadOnlyList<VehicleDisplacement>, IReadOnlyList<DisplacementDto>>(displacements);

        return Result<IReadOnlyList<DisplacementDto>>.Success(displacementsToReturn);
    }
}