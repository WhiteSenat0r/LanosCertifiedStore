using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTypeCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
    {
        var vehicleType = new VehicleType(request.Name);

        await unitOfWork.RetrieveRepository<VehicleType>().AddNewEntityAsync(vehicleType);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("CreateError", "Failed to create type!"));
    }
}