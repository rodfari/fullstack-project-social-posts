using Core.Application.Reponses;
using Core.Application.Reponses.UserResponses;

namespace Application.Contracts;
public interface IUserHandler
{
    Task<ResponseBase<GetUserResponse>> GetUserByIdAsync(int id);
    Task<ResponseBase<List<GetUserResponse>>> GetAllUserByIdAsync();
}