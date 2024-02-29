using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

internal sealed class TypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<TypesQuery, Result<IReadOnlyList<TypeDto>>>
{
    public async Task<Result<IReadOnlyList<TypeDto>>> Handle(TypesQuery request,
        CancellationToken cancellationToken)
    {
        var types = 
            await unitOfWork.RetrieveRepository<VehicleType>().GetAllEntitiesAsync(request.RequestParameters);

        var typesToReturn = mapper.Map<IReadOnlyList<VehicleType>, IReadOnlyList<TypeDto>>(types);

        return Result<IReadOnlyList<TypeDto>>.Success(typesToReturn);
    }
}