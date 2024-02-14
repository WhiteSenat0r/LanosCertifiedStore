using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateColorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var color = new VehicleColor(request.ColorName);

        await unitOfWork.RetrieveRepository<VehicleColor>().AddNewEntityAsync(color);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create color!");
    }
}