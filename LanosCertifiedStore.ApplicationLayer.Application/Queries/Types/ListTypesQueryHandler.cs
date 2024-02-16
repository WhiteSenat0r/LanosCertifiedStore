using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

internal sealed class ListTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListTypesQuery, Result<IReadOnlyList<TypeDto>>>
{
    public async Task<Result<IReadOnlyList<TypeDto>>> Handle(ListTypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = await unitOfWork.RetrieveRepository<VehicleType>().GetAllEntitiesAsync();

        var typesToReturn = mapper.Map<IReadOnlyList<VehicleType>, IReadOnlyList<TypeDto>>(types);

        return Result<IReadOnlyList<TypeDto>>.Success(typesToReturn);
    }
}