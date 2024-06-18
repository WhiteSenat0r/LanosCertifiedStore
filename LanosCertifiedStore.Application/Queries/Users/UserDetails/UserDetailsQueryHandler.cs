namespace Application.Queries.Users.UserDetails;

// TODO
// internal sealed class UserDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//     : IRequestHandler<UserDetailsQuery, Result<ProfileDto>>
// {
//     public async Task<Result<ProfileDto>> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
//     {
//         var user = await unitOfWork.RetrieveRepository<User>().GetEntityByIdAsync(request.Id);
//
//         if (user is null) return null!;
//
//         var userToReturn = mapper.Map<User, ProfileDto>(user);
//
//         return Result<ProfileDto>.Success(userToReturn);
//     }
// }