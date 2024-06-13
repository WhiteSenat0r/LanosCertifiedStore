using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleTypeRelated.DeleteType;

internal sealed class DeleteTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<DeleteTypeCommand, Result<Unit>>
{
    public DeleteTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteTypeError", "Vehicle type removal was not successful!"),
            new Error("DeleteTypeError", "Error occured during the vehicle type removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
    {
        await GetRequiredRepository<VehicleType>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}