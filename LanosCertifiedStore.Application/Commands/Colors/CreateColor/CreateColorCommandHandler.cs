namespace Application.Commands.Colors.CreateColor;

// TODO
// internal sealed class CreateColorCommandHandler 
//     : CommandHandlerBase<Unit>, IRequestHandler<CreateColorCommand, Result<Unit>>
// {
//     public CreateColorCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
//     {
//         PossibleErrors =
//         [
//             new Error("CreateColorError", "Saving a new color was not successful!"),
//             new Error("CreateColorError", "Error occured during a new color creation!")
//         ];
//     }
//
//     public async Task<Result<Unit>> Handle(CreateColorCommand request, CancellationToken cancellationToken)
//     {
//         var newColor = new VehicleColor(request.ColorName, request.HexValue);
//
//         await GetRequiredRepository<VehicleColor>().AddNewEntityAsync(newColor);
//
//         return await TrySaveChanges(cancellationToken);
//     }
// }