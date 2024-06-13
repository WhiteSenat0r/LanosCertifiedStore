using Application.Commands.Common;
using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Commands.Types.VehicleEngineTypeRelated.DeleteEngineType;

internal sealed class DeleteEngineTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<DeleteEngineTypeCommand, Result<Unit>>
{
    public DeleteEngineTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteEngineTypeError", "Engine type removal was not successful!"),
            new Error("DeleteEngineTypeError", "Error occured during the engine type removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteEngineTypeCommand request, CancellationToken cancellationToken)
    {
        await GetRequiredRepository<VehicleEngineType>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}