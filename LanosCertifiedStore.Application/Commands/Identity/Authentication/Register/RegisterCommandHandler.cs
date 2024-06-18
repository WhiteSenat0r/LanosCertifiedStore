namespace Application.Commands.Identity.Authentication.Register;

// TODO
// internal sealed class RegisterCommandHandler(
//     IAuthenticationService authenticationService,
//     IMapper mapper,
//     IUnitOfWork unitOfWork)
//     : IRequestHandler<RegisterCommand, Result<UserDto>>
// {
//     public async Task<Result<UserDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
//     {
//         var userRegisterResult = await authenticationService.RegisterAsync(request.RegisterDto);
//
//         var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;
//
//         return result
//             ? Result<UserDto>.Success(mapper.Map<User, UserDto>(userRegisterResult!))
//             : Result<UserDto>.Failure(new Error("Unauthorized", "Registration has failed"));
//     }
// }