using Application.Commands.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandHandlerHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<CreateColorCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateColorCommandHandlerHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        PossibleErrors = new[]
        {
            new Error("CreateColorError", "Saving a new color was not successful!"),
            new Error("CreateColorError", "Error occured during a new color creation!")
        };
    }

    public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
    {
        var newColor = new VehicleColor(request.ColorName, request.HexValue);

        await _unitOfWork.RetrieveRepository<VehicleColor>().AddNewEntityAsync(newColor);

        return await TrySaveChanges(cancellationToken);
    }
}