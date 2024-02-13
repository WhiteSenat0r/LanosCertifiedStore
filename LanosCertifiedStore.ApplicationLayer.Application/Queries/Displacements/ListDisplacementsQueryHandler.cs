using Application.Core;
using Application.Dtos.DisplacementDtos;
using Application.QuerySpecifications.DisplacementRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Displacements;

internal sealed class ListDisplacementsQueryHandler(
    IRepository<VehicleDisplacement> displacementRepository, IMapper mapper)
    : IRequestHandler<ListDisplacementsQuery, Result<IReadOnlyList<DisplacementDto>>>
{
    public async Task<Result<IReadOnlyList<DisplacementDto>>> Handle(ListDisplacementsQuery request,
        CancellationToken cancellationToken)
    {
        var displacements = await displacementRepository.GetAllEntitiesAsync(
            new DisplacementQuerySpecification());

        var displacementsToReturn = mapper.Map
            <IReadOnlyList<VehicleDisplacement>, IReadOnlyList<DisplacementDto>>(displacements);

        return Result<IReadOnlyList<DisplacementDto>>.Success(displacementsToReturn);
    }
}