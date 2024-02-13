using Application.Core;
using Application.Dtos.ColorDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Colors;

internal sealed class ListColorsQueryHandler(IRepository<VehicleColor> colorRepository, IMapper mapper)
    : IRequestHandler<ListColorsQuery, Result<IReadOnlyList<ColorDto>>>
{
    public async Task<Result<IReadOnlyList<ColorDto>>> Handle(ListColorsQuery request,
        CancellationToken cancellationToken)
    {
        var colors = await colorRepository.GetAllEntitiesAsync();

        var colorsToReturn = mapper.Map<IReadOnlyList<VehicleColor>, IReadOnlyList<ColorDto>>(colors);

        return Result<IReadOnlyList<ColorDto>>.Success(colorsToReturn);
    }
}