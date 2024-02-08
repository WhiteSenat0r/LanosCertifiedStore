using Application.Core;
using Application.Dtos.TypeDtos;
using Application.QuerySpecifications.TypeRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Types;

internal sealed class ListTypesQueryHandler(IRepository<VehicleType> typeRepository, IMapper mapper)
    : IRequestHandler<ListTypesQuery, Result<IReadOnlyList<TypeDto>>>
{
    public async Task<Result<IReadOnlyList<TypeDto>>> Handle(ListTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await typeRepository.GetAllEntitiesAsync(new TypeQuerySpecification());

        var typesToReturn = mapper.Map<IReadOnlyList<VehicleType>, IReadOnlyList<TypeDto>>(types);

        return Result<IReadOnlyList<TypeDto>>.Success(typesToReturn);
    }
}