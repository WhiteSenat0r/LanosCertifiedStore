using Application.Core;
using Application.Dtos.ColorDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors;

internal sealed class ListColorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListColorsQuery, Result<IReadOnlyList<ColorDto>>>
{
    public async Task<Result<IReadOnlyList<ColorDto>>> Handle(ListColorsQuery request,
        CancellationToken cancellationToken)
    {
        var colors = await unitOfWork.RetrieveRepository<VehicleColor>().GetAllEntitiesAsync();

        var colorsToReturn = mapper.Map<IReadOnlyList<VehicleColor>, IReadOnlyList<ColorDto>>(colors);

        return Result<IReadOnlyList<ColorDto>>.Success(colorsToReturn);
    }
}