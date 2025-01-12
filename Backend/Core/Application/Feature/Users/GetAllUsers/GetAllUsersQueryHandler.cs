using Core.Application.Reponses;
using Core.Application.Reponses.UserResponses;
using Core.Domain.Contracts;
using MediatR;

namespace Application.Feature.Users.GetAllUsers;
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserResponse>>
{
    private readonly IUserRepository _userRepository;
    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        
    }
    public async Task<IEnumerable<GetUserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users =  await _userRepository.GetAllAsync();
        var usersResponse = new List<GetUserResponse>();

        users.ForEach(user =>
        {
            usersResponse.Add(new GetUserResponse()
            {
                Id = user.Id,
                UserName = user.Username,
            });
        });

        
        return usersResponse.AsEnumerable();
    }
}