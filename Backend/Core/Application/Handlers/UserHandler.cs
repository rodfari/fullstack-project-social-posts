using Core.Application.Reponses;
using Core.Application.Reponses.UserResponses;
using Core.Domain.Contracts;

namespace Core.Application.Handlers;
public class UserHandler
{
    private readonly IUserRepository _userRepository;

    public UserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<TResponse<GetUserResponse>> GetUserByIdAsync(int id)
    {
        var user =  await _userRepository.GetByIdAsync(id);
        var userResponse = new GetUserResponse()
        {
            Id = user.Id,
            UserName = user.Username,
        };
        return new TResponse<GetUserResponse>(){
            Success = true,
            Data = userResponse
        };
    }

    public async Task<TResponse<List<GetUserResponse>>> GetAllUserAsync()
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

        
        return new TResponse<List<GetUserResponse>>(){
            Success = true,
            Data = usersResponse
        };
    }
}