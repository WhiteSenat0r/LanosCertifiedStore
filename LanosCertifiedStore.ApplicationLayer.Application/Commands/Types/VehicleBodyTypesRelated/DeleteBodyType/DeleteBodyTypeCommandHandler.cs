using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.VehicleBodyTypesRelated.DeleteBodyType;

internal sealed class DeleteBodyTypeCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<DeleteBodyTypeCommand, Result<Unit>>
{
    public DeleteBodyTypeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        PossibleErrors =
        [
            new Error("DeleteBodyTypeError", "Body type removal was not successful!"),
            new Error("DeleteBodyTypeError", "Error occured during the body type removal!")
        ];
    }

    public async Task<Result<Unit>> Handle(DeleteBodyTypeCommand request, CancellationToken cancellationToken)
    {
        await GetRequiredRepository<VehicleBodyType>().RemoveExistingEntityAsync(request.Id);

        return await TrySaveChanges(cancellationToken);
    }
}