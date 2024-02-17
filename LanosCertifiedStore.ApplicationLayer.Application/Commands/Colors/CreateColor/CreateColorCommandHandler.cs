using Application.Dtos.ColorDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var color = new VehicleColor(request.CreateColorDto.ColorName, request.CreateColorDto.HexValue);

        await unitOfWork.RetrieveRepository<VehicleColor>().AddNewEntityAsync(color);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("CreateError", "Failed to create color!"));
    }
}