namespace LanosCertifiedStore.Application.Images.Commands.AddImageToVehicle;

// TODO
// public class AddImageToVehicleCommandValidator : AbstractValidator<AddImageToVehicleCommand>
// {
//     public AddImageToVehicleCommandValidator()
//     {
//         RuleFor(x => x.Image)
//             .NotEmpty()
//             .Must(IsImageFile);
//
//         RuleFor(x => x.Image.Length)
//             .GreaterThan(VehicleImageConstants.MinimalFileSize);
//
//         RuleFor(x => x.VehicleId)
//             .NotEmpty();
//     }
//     
//     private bool IsImageFile(IFormFile imageFile) =>
//         string.Equals(imageFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) ||
//         string.Equals(imageFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) ||
//         string.Equals(imageFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase);
// }